using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using DAL.UOW;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	class PlatRepository : IPlatRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ServiceRepository> _logger;

		public PlatRepository(DbSession session, ILogger<ServiceRepository> logger)
		{
			_session = session;
			_logger = logger;
		}



		/// <summary>
		/// Permet d'obtenir la liste de tous les plats présents en BDD
		/// </summary>
		/// <returns>Retourne la liste des plats présents en BDD</returns>
		public async Task<IEnumerable<Plat>> GetAllAsync()
		{
			var stmt = @"select * from Plat";
			return await _session.Connection.QueryAsync<Plat>(stmt, null, _session.Transaction);
		}



		/// <summary>
		/// Permet d'obtenir la liste de tous les plats en fonction du type de plat
		/// </summary>
		/// <param name="idtypePlat"></param>
		/// <returns>Retourne une liste de plats en fonction du type de plat</returns>
		public async Task<IEnumerable<Plat>> GetAllThePlatsByTypePlat(int idtypePlat)
		{
			var stmt = @"select * from Plat where IdTypePlat = @idtypePlat";
			return await _session.Connection.QueryAsync<Plat>(stmt, new{@idtypePlat = idtypePlat}, _session.Transaction);
		}


		public async Task<IEnumerable<Plat>> GetAllPlatsByDayAndService(DateTime date, bool midi)
		{
			var stmt = @"SELECT p.IdPlat,Nom, s.IdService, IdTYpePlat FROM Services s Join ServicePlat sp on s.IdService = sp.IdService JOIN Plat p ON sp.IdPlat = p.IdPlat 
						where dateJourService = @date and midi = @midi
						ORDER BY  IdTypePlat ASC ";

			return await _session.Connection.QueryAsync<Plat>(stmt, new{@date = date, @midi = midi }, _session.Transaction);

		}


		 


		/// <summary>
		/// Permet d'obtenir un plat en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne un plat en fonction de son identifiant</returns>
		public async Task<Plat> GetAsync(int id)
		{
			var stmt = @"select p.*, pi.*, i.* from Plat as p 
						 innerJoin PlatIngredient as pi on pi.IdPlat = p.IdPlat,
					     innerJoin Ingredient as i on i.IdIngredient = pi.IdIngredient 
						 where IdPlat = @id";

			var plats = await _session.Connection.QueryAsync<Plat, PlatIngredient, Ingredient, Plat>(stmt,
				(plat, platIngredient, ingredient) => {
					plat.PlatIngredient = plat.PlatIngredient ?? new List<PlatIngredient>();
					platIngredient.Ingredient = ingredient;
					plat.PlatIngredient.Add(platIngredient);
					return plat;
				}, new { @id = id }, _session.Transaction, splitOn:"IdIngredient");


			var  p = plats.GroupBy( p => p.IdPlat).Select( pg => {
				Plat pgFirst  = pg.FirstOrDefault();
				pgFirst.PlatIngredient = pg.Select( pgi=> pgi.PlatIngredient.First()).ToList();
				return pgFirst;
			}).FirstOrDefault();

			return p;
		}



		/// <summary>
		/// Permet de mettre à jour un plat en BDD
		/// </summary>
		/// <param name="platToUpdate"></param>
		/// <returns>Retourne un boolean selon le resultat de la mise à jour</returns>
		public async Task<bool> UpdateAsync(Plat platToUpdate)
		{
			var stmt = @"update plat set nomPlat = @nomPlat, typePlat = @typePlat, score = @Score, Ingredients = @Ingredients from plat join ingredient where IdPlat = @IdPlat";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, platToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}




		/// <summary>
		/// Permet d'ajouter un nouveau plat en BDD
		/// </summary>
		/// <param name="platToCreate"></param>
		/// <returns>retourne un plat </returns>
		public async Task<Plat> InsertAsync(Plat platToCreate)
		{
			var stmt = @"insert into plat(Nom,Score,IdTypePlat) output INSERTED.IdPlat values (@nom,@score,2);";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, platToCreate, _session.Transaction);
				var stmtPlatIngredient =
					@"insert into PlatIngredient (IdPlat, IdIngredient, Quantite) output INSERTED.IdPlat values (@idPlat, @idIngredient, @Quantite)";
				platToCreate.PlatIngredient.ForEach(async platIngredient =>
				{
					await _session.Connection.QuerySingleAsync<int>(stmtPlatIngredient,
						new { idPlat = i, idIngredient = platIngredient.Ingredient.IdIngredient, Quantite = platIngredient.Quantite }, _session.Transaction);
				});

				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}



		
		


		/// <summary>
		/// Permet de supprimer un plat  en fonction de son identifiant
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns>Retourne un boolean en fonction du succes de la suppression</returns>
		public async Task<bool> DeleteAsync(int idPlat)
		{
			


			var queryParameters = new DynamicParameters();
			queryParameters.Add("IdPlat", idPlat);



			try
			{
				var i = await _session.Connection.ExecuteAsync(
					"SupprimerUnPlat",
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
		/// Permet d'obtenir la liste de tous les plats de façon paginée
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Retourne la liste des plats d efaçon paginée</returns>
		public async Task<PageResponse<Plat>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from plat
						ORDER BY IdPlat
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNT(*) FROM plat ";

			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Plat>(pageRequest.Page, pageRequest.PageSize, countTask, (platTask).ToList());
		}

		public async Task<PageResponseSortable<Plat>> GetAllByAsync(PageRequestSortable pageRequestSortable)
		{
			var stmt = @"select * from plat
						ORDER BY Score
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNT(*) FROM plat ";

			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, pageRequestSortable, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponseSortable<Plat>(pageRequestSortable.Score, pageRequestSortable.Page, pageRequestSortable.PageSize, countTask, (platTask).ToList());

		}


		/// <summary>
		/// Permet d'obtenir la liste de tous les plats de façon paginée et triée
		/// </summary>
		/// <param name="pageRequestSortable"></param>
		/// <returns></returns>
		public async Task<IEnumerable<Plat>> GetAllScoreAsync()
		{
			var stmt = @"select * from plat
						ORDER BY Score DESC";
						
			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, null, _session.Transaction);

			return await _session.Connection.QueryAsync<Plat>(stmt, null, _session.Transaction);

			

		}


		public async Task<IEnumerable<Plat>> GetAllPLatswithIngredientX(int IdIngredient)
		{

			var stmt = @"select * from Plat P JOIN PlatIngredient Pg ON P.IdPlat = Pg.IdPlat
					   JOIN Ingredient I ON Pg.IdIngredient = I.IdIngredient
					    WHERE I.IdIngredient = @IdIngredient";

			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, new {@IdIngredient = IdIngredient}, _session.Transaction);

			return platTask;
		}


	}
}
