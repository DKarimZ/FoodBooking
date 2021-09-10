using BO.Entity;
using DAL.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BO.DTO.Responses;
using BO.DTO.Requests;

namespace DAL.Repository
{
	class ServiceRepository : IServiceRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ServiceRepository> _logger;

		public ServiceRepository(DbSession session, ILogger<ServiceRepository> logger)
		{
			_session = session;
			_logger = logger;
		}



		/// <summary>
		/// Permet d'obtenir la liste de tous les services de la BDD sans pagination
		/// </summary>
		/// <returns>Retourne le liste des services de la BDD</returns>
		public async Task<IEnumerable<Service>> GetAllAsync()
		{
			var stmt = @"select * from Services";
			return await _session.Connection.QueryAsync<Service>(stmt, null, _session.Transaction);
		}



		/// <summary>
		/// Permet d'obtenir un service de la BDD en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne le service identifié</returns>
		public async Task<Service> GetAsync(int id)
		{
			var stmt = @"select * from Services where IdService = @id";
			var r = await _session.Connection.QueryFirstOrDefaultAsync<Service>(stmt, new {Id = id},
				_session.Transaction);
			return r;
		}

		public async Task<Plat> GetAsyncPlat0(int id)
		{
			var stmt = @"select * from ServicePlat where IdService = @id and IdPlat = (Select MIN(IdPlat) from ServicePlat where IdService = @id)";
			var r = await _session.Connection.QueryFirstOrDefaultAsync<Plat>(stmt, new { Id = id },
				_session.Transaction);
			return r;

		}

		public async Task<Plat> GetAsyncPlat1(int id)
		{
			var stmt = @"select * from ServicePlat where IdService = @id and IdPlat NOT IN ((Select MIN(IdPlat) from ServicePlat where IdService = @id), (Select MAX(IdPlat) from ServicePlat where IdService = @id))";
			var r = await _session.Connection.QueryFirstOrDefaultAsync<Plat>(stmt, new { Id = id },
				_session.Transaction);
			return r;

		}

		public async Task<Plat> GetAsyncPlat2(int id)
		{
			var stmt = @"select * from ServicePlat where IdService = @id and IdPlat = (Select MAX(IdPlat) from ServicePlat where IdService = @id)";
			var r = await _session.Connection.QueryFirstOrDefaultAsync<Plat>(stmt, new { Id = id },
				_session.Transaction);
			return r;

		}


		public async Task<Service> GetServiceByDateAndMidi(DateTime date, bool midi)
		{
			var stmt = @"select s.*, sp.*,p.*,tp.* from Services s 
						left join ServicePlat sp ON s.Idservice = sp.IdService
						left join Plat p ON sp.IdPlat = p.IdPlat
						left join TypePlat tp on p.IdTypePlat = tp.IdTypePlat
						where dateJourService = @date and Midi = @midi
						ORDER by p.IdTypePlat"
;
			var service = await _session.Connection.QueryAsync<Service,Plat,TypePlat,Service>(stmt,(service,plat,typePlat) =>
				{
				service.Plats = service.Plats ?? new List<Plat>();
				service.Plats.Add(plat);
				plat.typePlat = typePlat;
				return service;
				},new { midi = midi, date = date }, _session.Transaction, splitOn: "IdPlat,IdTypePlat");

			var s = service.GroupBy(p => p.IdService).Select(pg => {
				Service pgFirst = pg.FirstOrDefault();
				pgFirst.Plats = pg.Select(pgi => pgi.Plats.First()).ToList();
				return pgFirst;
			}).FirstOrDefault();

			return s;

		}


		/// <summary>
		/// Permet de mettre a jour un service de la BDD en utilisant une procédure stockéd
		/// </summary>
		/// <param name="menuToUpdate"></param>
		/// <returns>Retourne un boolean selon le resultat de la mise à jour</returns>
		public async Task<bool> UpdateAsync(Service menuToUpdate)
		{
			Plat oldServiceP0 = await GetAsyncPlat0(menuToUpdate.IdService);
			Plat oldServiceP1 = await GetAsyncPlat1(menuToUpdate.IdService);
			Plat oldServiceP2 = await GetAsyncPlat2(menuToUpdate.IdService);

			var queryParameters = new DynamicParameters();

			queryParameters.Add("IdService", menuToUpdate.IdService);

			queryParameters.Add("IdPlat1Old", oldServiceP0.IdPlat);
			queryParameters.Add("IdPlat2Old", oldServiceP1.IdPlat);
			queryParameters.Add("IdPlat3Old", oldServiceP2.IdPlat);

			queryParameters.Add("IdPlat1New", menuToUpdate.Plats[0].IdPlat);
			queryParameters.Add("IdPlat2New", menuToUpdate.Plats[1].IdPlat);
			queryParameters.Add("IdPlat3new", menuToUpdate.Plats[2].IdPlat);
			
			try
			{
				var i = await _session.Connection.ExecuteAsync(
					"ModifierUnService",
					queryParameters,
					commandType: CommandType.StoredProcedure, transaction: _session.Transaction);


				return i > 0;

			}
			catch (Exception e)
			{
				_logger.LogWarning(e.Message);
				return false;

			}

		}



		/// <summary>
		/// Permet d'ajouter un service en BDD 
		/// </summary>
		/// <param name="menuToCreate"></param>
		/// <returns></returns>
		public async Task<Service> InsertAsync(Service menuToCreate)
		{
			var stmt =
				@"insert into Services (Midi, dateJourservice) output INSERTED.IdService values ( @Midi, @datejourservice)";

			try
			{
				var i = await _session.Connection.QuerySingleAsync<int>(stmt, menuToCreate, _session.Transaction);

				var stmtServicePlat =
					@"insert into ServicePlat (IdService, IdPlat) output INSERTED.IdService values (@idService, @idPlat)";
				menuToCreate.Plats.ForEach(async plat =>
				{
					await _session.Connection.QuerySingleAsync<int>(stmtServicePlat,
						new {idService = i, idPlat = plat.IdPlat}, _session.Transaction);
				});

				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}




		/// <summary>
		/// Permet de supprimer un service en BDD en fonction de son identifiant
		/// </summary>
		/// <param name="idService"></param>
		/// <returns>Retourne un boolean selon le resultat ded la suppression</returns>
		public async Task<bool> DeleteAsync(int idService)
		{

			var queryParameters = new DynamicParameters();
			queryParameters.Add("IdService", idService);



			try
			{
				var i = await _session.Connection.ExecuteAsync(
					"EffacerUnService",
					queryParameters,
					commandType: CommandType.StoredProcedure, transaction: _session.Transaction);


				return i > 0;

			}
			catch (Exception e)
			{
				_logger.LogWarning(e.Message);
				return false;

			}
		}

		
	}
}
