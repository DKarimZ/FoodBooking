using BO.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{
	class FakeMenuRepository : IMenuRepository
	{
		List<Menu> MenuDb = new List<Menu>()
		{
			new Menu(13,"Mardi",new Plat()),
			new Menu(14,"Mercredi",new Plat()),
			new Menu(15,"Jeudi",new Plat()),

		};
		public Task<bool> DeleteAsync(int id)
		{
			if (id > 15)
			{
				return Task.FromResult(false);
			}

			else
			{
				return Task.FromResult(true);
			}
			
		}

		public Task<IEnumerable<Menu>> GetAllAsync()
		{
			
			return Task.FromResult(MenuDb as IEnumerable<Menu>);
				
		}

		public Task<Menu> GetAsync(int id)
		{
			if (id > 15) {
				return Task.FromResult<Menu>(null);
			};

			return Task.FromResult(new Menu()
			{
				IdMenu = id,
				firstDayweek = "Lundi",
				Plats = new Plat()
			});
		}

		public Task<Menu> InsertAsync(Menu entity)
		{
			if (entity != null)
			{
				entity.IdMenu = 1;
				return Task.FromResult(entity);
			}
			else
			{
				return Task.FromResult<Menu>(null);
			}

		}

		public Task<bool> UpdateAsync(Menu entity)
		{	if (entity == null)
			{
				throw new Exception();
			}

			if (entity.IdMenu == null)
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
