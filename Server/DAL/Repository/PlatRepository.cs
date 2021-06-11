using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using DAL.UOW;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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



		/// <summary>
		/// Permet d'obtenir un plat en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne un plat en fonction de son identifiant</returns>
		public async Task<Plat> GetAsync(int id)
		{
			var stmt = @"select * from Plat where IdPlat = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Plat>(stmt, new { @id = id }, _session.Transaction);
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
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}



		/// <summary>
		/// Permet d'ajouter plusieurs ingredient - A redefinir
		/// </summary>
		/// <param name="ingredientToAdd"></param>
		/// <returns></returns>

		public async Task<PlatIngredient> InsertIngredientsAsync(Ingredient ingredientToAdd)
		{
			//var stmt =
			//	@"insert into PlatIngredient(IdPlat, IdIngredient,Quantite) values (@Idplat,@IdIngredient,@Quantite);";
			//try
			//{
			//	int i = await _session.Connection.QuerySingleAsync<int>(stmt, platToCreate, _session.Transaction);
			//	return await GetAsync(i);
			//}

			//catch
			//{
			//	return null;
			//}
			return new();

			//TODO Finir la methode d'ajout de plat (et d'ingredients)
		}



		/// <summary>
		/// Permet de supprimer un plat  en fonction de son identifiant
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns>Retourne un boolean en fonction du succes de la suppression</returns>
		public async Task<bool> DeleteAsync(int idPlat)
		{
			var stmt = @"delete from plat where IdPlat = @IdPlat";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { idMenu = idPlat }, _session.Transaction);
				return i > 0;
			}
			catch
			{
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




		/// <summary>
		/// Permet d'obtenir la liste de tous les plats de façon paginée et triée
		/// </summary>
		/// <param name="pageRequestSortable"></param>
		/// <returns></returns>
		public async Task<PageResponseSortable<Plat>> GetAllAsync(PageRequestSortable pageRequestSortable)
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


		


	}
}
