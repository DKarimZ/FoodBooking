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
	class FakeIngredientRepository : IIngredientRepository
	{

		List<Ingredient> IngredientDb = new List<Ingredient>()
		{
			new Ingredient(21,"Oeil de tortue",1500),
			new Ingredient(22,"Oeil de grenouille",150),
			new Ingredient(21,"Oeil de lezard",10),

		};

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

		public Task<IEnumerable<Ingredient>> GetAllAsync()
		{
			return Task.FromResult(IngredientDb as IEnumerable<Ingredient>);
		}

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
					nomIngredient = "ailes de mouches",
					prixMoyen = 13

				});
			}
		}

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
