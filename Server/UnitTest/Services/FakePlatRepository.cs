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
	class FakePlatRepository : IPlatRepository
	{


		public Task<bool> DeleteAsync(int id)
		{
			
		}

		public Task<IEnumerable<Plat>> GetAllAsync()
		{
		}

		public Task<PageResponse<Plat>> GetAllAsync(PageRequest pageRequest)
		{
		
		}

		public Task<PageResponseSortable<Plat>> GetAllAsync(PageRequestSortable PageRequestSortable)
		{
			
		}

		public Task<Plat> GetAsync(int id)
		{
			
		}

		public Task<Plat> InsertAsync(Plat entity)
		{
			
		}

		public Task<bool> UpdateAsync(Plat entity)
		{
			throw new NotImplementedException();
		}
	}
}
