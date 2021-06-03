using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{
	/// <summary>
	/// Testing the Ingredient Repository / methods
	/// </summary>
	class FakeIngredientRepository : IIngredientRepository
	{

		//List of Ingrdients
		List<Ingredient> IngredientDb = new List<Ingredient>()
		{
			new Ingredient(21,"Oeil de tortue",1500),
			new Ingredient(22,"Oeil de grenouille",150),
			new Ingredient(21,"Oeil de lezard",10),

		};


		/// <summary>
		/// Testing the Delete method of the Ingredient Repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns a boolean : false if the id > 55 or true if the id <= 55</returns>
		public Task<bool> DeleteAsync(int id)
		{
			if (id > 55)
			{
				return Task.FromResult(false);
			}
			else
			{
				return Task.FromResult(true);

			}


		}

		/// <summary>
		/// Tessting the GetAll method of the Ingredient repository
		/// </summary>
		/// <returns>Returns a list(casted to IEnumerable) of Ingredients </returns>
		public Task<IEnumerable<Ingredient>> GetAllAsync()
		{
			return Task.FromResult(IngredientDb as IEnumerable<Ingredient>);
		}

		/// <summary>
		/// Testing the GetAll method using a pageRequest of the Ingredient Repository
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Returns a pageresponse of Ingredient</returns>
		public Task<PageResponse<Ingredient>> GetAllAsync(PageRequest pageRequest)
		{
			return Task.FromResult(new PageResponse<Ingredient>()
			{
				Page = pageRequest.Page,
				PageSize = pageRequest.PageSize,
				Data = IngredientDb,
				TotalRecords = 120

			});
		}

		/// <summary>
		/// Testing the Get (by Id) method of the Ingredient Repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>returns null if the id of teh Ingredient > 30 or returns the ingredient</returns>
		public Task<Ingredient> GetAsync(int id)
		{
			if (id > 30)
			{
				return Task.FromResult<Ingredient>(null);
			}
			else
			{
				return Task.FromResult(new Ingredient()
				{
					IdIngredient = 1,
					NomIngredient = "ailes de mouches",
					PrixMoyen = 13

				});
			}
		}

		/// <summary>
		/// Testing the Insert method of the Ingredient Repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>Returns null if no ingredient is insert (ingredient = null ) or returns the ingredient created</returns>
		public Task<Ingredient> InsertAsync(Ingredient entity)
		{
			if (entity != null)
			{
				entity.IdIngredient = 1;
				return Task.FromResult(entity);

			}
			else
			{
				return Task.FromResult<Ingredient>(null);
			}
		}

		/// <summary>
		/// Testing the Update method of the Ingredient Repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>Returns  an exception if the entity is null, returns false if the IdIngredient id is null and true if the IdIngredient is the same than the updated one</returns>
		public Task<bool> UpdateAsync(Ingredient entity)
		{
			if (entity == null)
			{
				throw new Exception();
			}

			if (entity.IdIngredient == null)
			{
				return Task.FromResult(false);
			}
			else
			{
				return Task.FromResult(true);
			}
		}
	}
}
