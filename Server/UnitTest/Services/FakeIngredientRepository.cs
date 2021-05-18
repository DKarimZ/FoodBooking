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
		public Task<bool> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Ingredient>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<PageResponse<Ingredient>> GetAllAsync(PageRequest pageRequest)
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> InsertAsync(Ingredient entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(Ingredient entity)
		{
			throw new NotImplementedException();
		}
	}
}
