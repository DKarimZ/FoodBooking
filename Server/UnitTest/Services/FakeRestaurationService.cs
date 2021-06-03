using BLL.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{

	/// <summary>
	/// Testing the RestaurationService methods by creating a Fake one 
	/// </summary>
	class FakeRestaurationService : IRestaurationService
	{

		//Creating a new List of menus called MenuDb
		public List<Service> ServiceDb = new List<Service>()
			{
				new Service(1, true,
					new(){ }
					)};

			

		//Creating a new List of ingredients called IngredientDb
		public List<Ingredient> IngredientDb = new List<Ingredient>()
		{
			new Ingredient(3,"poulet",8),
			new Ingredient(4,"oignons",2),
			new Ingredient(5,"gingembre",3)

		};

		//Creating a new List of Plats called PlatDb
		public List<Plat> PlatDb = new List<Plat>
		{
			new Plat(1,"sauté de boeuf",new TypePlat(),13,new List<PlatIngredient>()
			{
				new PlatIngredient(new Ingredient(1,"champignons",4), 5), 
				new PlatIngredient(new Ingredient(1,"navet", 4), 0.3f)

			})
		};


		/// <summary>
		/// Testing the CreatingIngredient method of the Restauration service
		/// </summary>
		/// <param name="newIngredient"></param>
		/// <returns>returns the new Ingredient if her name is not null and returns null in the other case</returns>
		Task<Ingredient> IRestaurationService.CreateIngredient(Ingredient newIngredient)
		{
			if (newIngredient.NomIngredient != null)
			{
				return Task.FromResult(newIngredient);
			}

			else
			{
				return Task.FromResult<Ingredient>(null);
			}
		}

		/// <summary>
		/// Testingg the CreateService method of the restauration Service
		/// </summary>
		/// <param name="newMenu"></param>
		/// <returns>Returns the new Menu if the firstDayWeek attribute is not null and returns null in the other case</returns>
		Task<Service> IRestaurationService.CreateService(Service newService)
		{
			if (newService.IdService!= null)
			{
				return Task.FromResult(newService);
			}

			else
			{
				return Task.FromResult<Service>(null);
			}
		}

		/// <summary>
		/// Testing the createPlat method of the Restauration Service
		/// </summary>
		/// <param name="newPlat"></param>
		/// <returns>Returns the new plat created if the nomPlat attribute is not null or returns null  in nthe other case</returns>
		Task<Plat> IRestaurationService.CreatePlat(Plat newPlat)
		{
			if (newPlat.nomPlat != null)
			{
				return Task.FromResult(newPlat);
			}

			else
			{
				return Task.FromResult<Plat>(null);
			}
		}

		/// <summary>
		/// Testing the GetAllIngredients method of the Restauration Service
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Returns a PageResponse<Ingredient> corresponding  to the list of Ingredients pageable</Ingredient></returns>
		Task<PageResponse<Ingredient>> IRestaurationService.GetAllIngredients(PageRequest pageRequest)
		{

			List<Ingredient> data = null;

			if (pageRequest.Page * pageRequest.PageSize < IngredientDb.Count)
			{
				int firstIndex = pageRequest.Page * pageRequest.PageSize;
				int lastIndex = ((pageRequest.Page * pageRequest.PageSize) + pageRequest.PageSize) - 1;
				Math.Clamp(lastIndex, 0, IngredientDb.Count);

				data = IngredientDb.GetRange(firstIndex, lastIndex - firstIndex);
			}

			return Task.FromResult(new PageResponse<Ingredient>()
			{
				Page = pageRequest.Page,
				PageSize = pageRequest.PageSize,
				TotalRecords = IngredientDb.Count,
				Data = data

			});




		}

		/// <summary>
		/// Testing the GetALlMenus method of the restauration Service
		/// </summary>
		/// <returns>Returns the list of the Menus</returns>
		Task<List<Service>> IRestaurationService.GetAllServices()
		{

			return Task.FromResult(ServiceDb);

		}

		/// <summary>
		/// Testing the GetAllPlats method of the restauration Service
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Returns a PageResponse<Plat> corresponding to the list of the plats pageable</returns>
		Task<PageResponse<Plat>> IRestaurationService.GetAllPlats(PageRequest pageRequest)
		{
			List<Plat> data = null;
			if (pageRequest.Page * pageRequest.PageSize < PlatDb.Count)
			{
				int firstIndex = pageRequest.Page * pageRequest.PageSize;
				int lastIndex = ((pageRequest.Page * pageRequest.PageSize) + pageRequest.PageSize) - 1;
				Math.Clamp(lastIndex, 0, PlatDb.Count);

				data = PlatDb.GetRange(firstIndex, lastIndex - firstIndex);
			}

			return Task.FromResult(new PageResponse<Plat>()
			{
				Page = pageRequest.Page,
				PageSize = pageRequest.PageSize,
				TotalRecords = PlatDb.Count,
				Data = data

			});
		}

		/// <summary>
		/// Testing the GetIngredientById method of the restauration service
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <returns>Returns the Ingredient corresponding to the IdIngredient</returns>
		Task<Ingredient> IRestaurationService.GetIngredientById(int idIngredient)
		{
			return Task.FromResult(IngredientDb.Find(b => b.IdIngredient == idIngredient));
		}

		/// <summary>
		/// Testing the GetMenuBybId method of the Restaurationn Service
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>Returns the menu of the MenuDb corresponding to the corresponding idMenu</returns>
		Task<Service> IRestaurationService.GetServiceById(int idService)
		{
			return Task.FromResult(ServiceDb.Find(b => b.IdService == idService));
		}

		/// <summary>
		/// Testing the GetPlatById method of the restauration Service
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns>Returns the plat from the PlatDb corresponding to the idPlat</returns>
		Task<Plat> IRestaurationService.GetPlatById(int idPlat)
		{
			return Task.FromResult(PlatDb.Find(b => b.IdPlat == idPlat));
		}

		/// <summary>
		/// Testing the RemoveIngredient method from the Restauration Service
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <returns>Returns true if the idIngredient to remove belongs to the IngredientDb list</returns>
		Task<bool> IRestaurationService.RemoveIngredient(int idIngredient)
		{
			int i = IngredientDb.RemoveAll(b => b.IdIngredient == idIngredient);
			return Task.FromResult(i > 0);
		}

		/// <summary>
		/// Testing the RemoveMenu method from the restauration Service
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>Returns true if the idMenu belongs to the MenuDb list</returns>
		Task<bool> IRestaurationService.RemoveService(int idService)
		{
			int i = ServiceDb.RemoveAll(b => b.IdService == idService);
			return Task.FromResult(i > 0);
		}

		/// <summary>
		/// Testing the removePlat method of the restauration Service
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns>Returns true if the idPlat belongs to the PlatDb list</returns>
		Task<bool> IRestaurationService.RemovePlat(int idPlat)
		{
			int i = PlatDb.RemoveAll(b => b.IdPlat == idPlat);
			return Task.FromResult(i > 0);
		}

		/// <summary>
		/// Testing the UpdateIngredient method of the restauration Service
		/// </summary>
		/// <param name="ingredientToUpdate"></param>
		/// <returns>Returns the ingredient updated if his idIngredient belongs to the IngredientDb</returns>
		Task<Ingredient> IRestaurationService.UpdateIngredient(Ingredient ingredientToUpdate)
		{
			var _ingredient = IngredientDb.Find(b => b.IdIngredient == ingredientToUpdate.IdIngredient);
			_ingredient.NomIngredient = ingredientToUpdate.NomIngredient;
			_ingredient.PrixMoyen = ingredientToUpdate.PrixMoyen;

			return Task.FromResult(_ingredient);
		}

		/// <summary>
		/// Testing the UpdateService of the Restauration Service
		/// </summary>
		/// <param name="menuToUpdate"></param>
		/// <returns>Returns the menuUpdated if his id belongs to the MenuDb list</returns>
		Task<Service> IRestaurationService.UpdateService(Service serviceToUpdate)
		{
			var _service = ServiceDb.Find(b => b.IdService == serviceToUpdate.IdService);
			_service.Midi = serviceToUpdate.Midi;
			_service.dateJourservice = serviceToUpdate.dateJourservice;

			return Task.FromResult(_service);

		}

		/// <summary>
		/// Testing the UpdatePlat method of the Restauration Service
		/// </summary>
		/// <param name="platToUpdate"></param>
		/// <returns>Returns the plat updated if his Id belongs to the PlatDb list</returns>
		Task<Plat> IRestaurationService.UpdatePlat(Plat platToUpdate)
		{
			var _plat = PlatDb.Find(b => b.IdPlat == platToUpdate.IdPlat);
			_plat.nomPlat = platToUpdate.nomPlat;
			_plat.typePlat = platToUpdate.typePlat;
			_plat.Score = platToUpdate.Score;
			_plat.PlatIngredient = platToUpdate.PlatIngredient;

			return Task.FromResult(_plat);
		}
	}
}
