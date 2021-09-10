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
	/// Testing of the Plat Repository
	/// </summary>
	class FakePlatRepository : IPlatRepository
	{
		//Creating a list of Plat
		List<Plat> PlatDb = new List<Plat>()
		{
			new Plat(18,"boeuf bourguignon",new TypePlat(1,"entree"),0,new List<PlatIngredient>()),
			new Plat(19,"Tarte à l'oignon",new TypePlat(2,"plat"),1,new List<PlatIngredient>()),
			new Plat(20,"Tarte aux poireaux",new TypePlat(3,"dessert"),1,new List<PlatIngredient>()),

		};

		/// <summary>
		/// Testing the Delete Mothod of the Plat Reository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns fale if the Id of the plat > 25 and true if Id is >= 25</returns>
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

		/// <summary>
		/// Testing the GetAll method of the Plat Repository
		/// </summary>
		/// <returns>Returns a List(casted in IEnumerable) of Plats</returns>
		public Task<IEnumerable<Plat>> GetAllAsync()
		{
			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}

		/// <summary>
		/// Testing the second GetAll method of the Plat Repository
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Returns a PageResponse<Plat> , a list of plats pageable</returns>
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


		/// <summary>
		/// Testing the thirdh GetAll method of the plat Repository
		/// </summary>
		/// <param name="pageRequestSortable"></param>
		/// <returns>Returns a PageResponseSortable<Plat>, a list of sortable and pageable plats</Plat></returns>
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


		/// <summary>
		/// Testing the GetById method of the Plat Repository
		/// </summary>
		/// <param name="id"></param>
		/// <returns>returns null if the id > 15 or returns the new plat if id <= 15</returns>
		public Task<Plat> GetAsync(int id)
		{
			
			if (id > 15)
			{
				return Task.FromResult<Plat>(null);
			};

			return Task.FromResult(new Plat()
			{
				IdPlat = id,
				Nom = "confit de canard aux olives",
				Score = 1,
				PlatIngredient = new List<PlatIngredient>()
			});
		}


		/// <summary>
		/// Testing the Insert method of the Plat Repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>Returns the entity Plat if the entity to Insert is not null and returns null if the entity is null</returns>
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


		/// <summary>
		/// Testing the Update Method of the Plat Repository
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>returns an exception if the Plat entity to update is null or returns false if the IdEntity is null or returns true in the others cases</returns>
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

		public Task<IEnumerable<Plat>> GetAllThePlatsByTypePlat(int idtypePlat){

			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}

		public Task<IEnumerable<Plat>> GetAllScoreAsync(){

			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}

		public Task<IEnumerable<Plat>> GetAllPLatswithIngredientX(int Idingredient){

			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}

		public Task<IEnumerable<Plat>> GetAllPlatsByDayAndService(DateTime date, bool midi){

			return Task.FromResult(PlatDb as IEnumerable<Plat>);
		}
	}
}
