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
	/// <summary>
	/// Permet l'accès aux données Ingredient de la BDD
	/// </summary>
	public class IngredientRepository : IIngredientRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<IngredientRepository> _logger;

		public IngredientRepository(DbSession session, ILogger<IngredientRepository> logger)
		{
			_session = session;
			_logger = logger;
		}


		/// <summary>
		/// Permet d'obtenir la liste des ingrédients présents en BDD
		/// </summary>
		/// <returns>Retourne la liste des ingrédients</returns>
		public async Task<IEnumerable<Ingredient>> GetAllAsync()
		{
			var stmt = @"select * from Ingredient";
			return await _session.Connection.QueryAsync<Ingredient>(stmt, null, _session.Transaction);
		}


		/// <summary>
		/// Permet d'obtenir un ingrédient présent en BDD en foonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne l'ingrédient identifié</returns>
		public async Task<Ingredient> GetAsync(int id)
		{
			var stmt = @"select * from ingredient where IdIngredient = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Ingredient>(stmt, new { @id = id }, _session.Transaction);

		}


		/// <summary>
		/// Permet de mettre à jour un ingrédient présent en BDD
		/// </summary>
		/// <param name="ingredientToUpdate"></param>
		/// <returns>Retourne un boolean en fonction de la réussite de la mise à jour</returns>
		public async Task<bool> UpdateAsync(Ingredient ingredientToUpdate)
		{
			var stmt = @"update ingredient set NomIngredient = @NomIngredient, PrixMoyen = @PrixMoyen from ingredient where IdIngredient = @Idingredient";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, ingredientToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}


		/// <summary>
		/// Permet d'ajouter un ingrédient en BDD
		/// </summary>
		/// <param name="ingredientToCreate"></param>
		/// <returns>Retourne l'ingrédient créé</returns>
		public async Task<Ingredient> InsertAsync(Ingredient ingredientToCreate)
		{
			var stmt = @"insert into ingredient(NomIngredient, PrixMoyen) output INSERTED.ID values (@NomIngredient, @PrixMoyen)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, ingredientToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}


		/// <summary>
		/// Permet de supprimer un ingrédient en fonctionde son identifiant
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <returns></returns>
		public async Task<bool> DeleteAsync(int idIngredient)
		{
			var stmt = @"delete from ingredient where Idingredient = @IdIngredient";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { IdIngredient = idIngredient }, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;

			}
		}


		/// <summary>
		/// Permet d'obtenir la liste de tous les ingrédients en base de données de façon paginée
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns></returns>
		public async Task<PageResponse<Ingredient>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from Ingredient
						ORDER BY IdIngredient
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNt(*) FROM Ingredient ";

			IEnumerable<Ingredient> ingredientTask = await _session.Connection.QueryAsync<Ingredient>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Ingredient>(pageRequest.Page, pageRequest.PageSize, countTask, (ingredientTask).ToList());
		}
	}
}

