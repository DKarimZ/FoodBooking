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
	/// testing the Menu Repository methods
	/// </summary>
	class FakeMenuRepository : IServiceRepository
	{
		//List of menu created for the testing of Menu Repository
		List<Service> ServiceDb = new List<Service>()
		{
			new Service(13,true,new ()),
			new Service(14,false,new ()),
			new Service(15,true,new ()),

		};


		/// <summary>
		/// Testing the Delete method of the Menu repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns true if the Id<= 15 or false if Id > 15</returns>
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

		/// <summary>
		/// Testing the GetAll method of the Menu Repository
		/// </summary>
		/// <returns>returns the list (casted in IEnumerable) of the menus</returns>
		public Task<IEnumerable<Service>> GetAllAsync()
		{
			
			return Task.FromResult(ServiceDb as IEnumerable<Service>);
				
		}

		/// <summary>
		/// Testing the Get method of the Menu Repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns null if the id of the menu > 15 or returns the menu if the id <= 15</returns>
		public Task<Service> GetAsync(int id)
		{
			if (id > 15) {
				return Task.FromResult<Service>(null);
			};

			return Task.FromResult(new Service()
			{
				IdService = id,
				Midi = true,
				dateJourservice = new ()
			});
		}

		/// <summary>
		/// Testing the Insert method of the menu repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>returns the menu entity if the entity != null or returns null if the entity is null </returns>
		public Task<Service> InsertAsync(Service entity)
		{
			if (entity != null)
			{
				entity.IdService = 1;
				return Task.FromResult(entity);
			}
			else
			{
				return Task.FromResult<Service>(null);
			}

		}

		/// <summary>
		/// Testing the Update method of the menu repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>returns ann exception if the entity menu is null or returns flase if the IdMeu of the entity to update is null or returns true </returns>
		public Task<bool> UpdateAsync(Service entity)
		{	if (entity == null)
			{
				throw new Exception();
			}

			if (entity.IdService == null)
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
