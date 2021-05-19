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
		List<Plat> PlatDb = new List<Plat>()
		{
			new Plat(18,"boeuf bourguignon","entree",1,new List<Ingredient>()),
			new Plat(19,"Tarte à l'oignon","plat",1,new List<Ingredient>()),
			new Plat(20,"Tarte aux poireaux","plat",1,new List<Ingredient>()),

		};

		public Task<bool> DeleteAsync(int id)
		{
			if (id > 25)
			{
				return Task.FromResult(false);
			}
			else
			{
				return Task.FromResult(true);
			}


		}

		public Task<IEnumerable<Plat>> GetAllAsync()
		{
			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}

		public Task<PageResponse<Plat>> GetAllAsync(PageRequest pageRequest)
		{
			return Task.FromResult(new PageResponse<Plat>()
			{
				Page = pageRequest.Page,
				PageSize = pageRequest.PageSize,
				Data = PlatDb,
				TotalRecords= 100
			}) ;
		}

		public Task<PageResponseSortable<Plat>> GetAllAsync(PageRequestSortable pageRequestSortable)
		{
			return Task.FromResult(new PageResponseSortable<Plat>()
			{
				Page = pageRequestSortable.Page,
				PageSize = pageRequestSortable.PageSize,
				Data = PlatDb,
				TotalRecords = 100,
				Score= 10				
			});
		}

		public Task<Plat> GetAsync(int id)
		{
			
			if (id > 15)
			{
				return Task.FromResult<Plat>(null);
			};

			return Task.FromResult(new Plat()
			{
				IdPlat = id,
				nomPlat = "confit de canard aux olives",
				Score = 1,
				Ingredients = new List<Ingredient>()
			});
		}

		public Task<Plat> InsertAsync(Plat entity)
		{
			if (entity != null)
			{
				entity.IdPlat = 1;
				return Task.FromResult(entity);
			}
			else
			{
				return Task.FromResult<Plat>(null);
			}
		}

		public Task<bool> UpdateAsync(Plat entity)
		{
			if (entity == null)
			{
				throw new Exception();
			}

			if (entity.IdPlat == null)
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
