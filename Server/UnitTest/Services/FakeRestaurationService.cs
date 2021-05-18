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
	class FakeRestaurationService : IRestaurationService
	{
		public Plat nouilles = new Plat()
		{
			IdPlat = 1,
			nomPlat = "nouilles sautees",
			typePlat = "Entree",
			Score = 5,
			Ingredients = new List<Ingredient>() { new Ingredient() { IdIngredient = 1, nomIngredient = "carottes", prixMoyen = 5 } }

		};
		public List<Menu> MenuDb = new List<Menu>()
			{
				new Menu(1, "Lundi", new Plat(){
			IdPlat = 1,
			nomPlat = "nouilles sautees",
			typePlat = "Entree",
			Score = 5,
			Ingredients = new List<Ingredient>() { new Ingredient() { IdIngredient = 1, nomIngredient = "carottes", prixMoyen = 5 } } }),

			new Menu(1, "Lundi", new Plat(){
			IdPlat = 2,
			nomPlat = "boeuf aux oignons",
			typePlat = "Plat",
			Score = 8,
			Ingredients = new List<Ingredient>() { new Ingredient() { IdIngredient = 2, nomIngredient = "boeuf", prixMoyen = 20 } } }),

			};

		public List<Ingredient> IngredientDb = new List<Ingredient>()
		{
			new Ingredient(3,"poulet",8),
			new Ingredient(4,"oignons",2),
			new Ingredient(5,"gingembre",3)

		};

		public List<Plat> PlatDb = new List<Plat>
		{
			new Plat(3,"sauté de boeuf","plat",13,new List<Ingredient>(){
				new Ingredient(6,"champignons",4),
				new Ingredient(7,"sauce soja",2)
		

				})
		};

		Task<Ingredient> IRestaurationService.CreateIngredient(Ingredient newIngredient)
		{
			if (newIngredient.nomIngredient != null)
			{
				return Task.FromResult(newIngredient);
			}

			else
			{
				return Task.FromResult<Ingredient>(null);
			}
		}

		Task<Menu> IRestaurationService.CreateMenu(Menu newMenu)
		{
			if (newMenu.firstDayweek != null)
			{
				return Task.FromResult(newMenu);
			}

			else
			{
				return Task.FromResult<Menu>(null);
			}
		}

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

		Task<List<Menu>> IRestaurationService.GetAllMenus()
		{

			return Task.FromResult(MenuDb);

		}

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

		Task<Ingredient> IRestaurationService.GetIngredientById(int idIngredient)
		{
			return Task.FromResult(IngredientDb.Find(b => b.IdIngredient == idIngredient));
		}

		Task<Menu> IRestaurationService.GetMenuById(int idMenu)
		{
			return Task.FromResult(MenuDb.Find(b => b.IdMenu == idMenu)); 
		}

		Task<Plat> IRestaurationService.GetPlatById(int idPlat)
		{
			return Task.FromResult(PlatDb.Find(b => b.IdPlat == idPlat));
		}

		Task<bool> IRestaurationService.RemoveIngredient(int idIngredient)
		{
			int i = IngredientDb.RemoveAll(b => b.IdIngredient == idIngredient);
			return Task.FromResult(i > 0);
		}

		Task<bool> IRestaurationService.RemoveMenu(int idMenu)
		{
			int i = MenuDb.RemoveAll(b => b.IdMenu == idMenu);
			return Task.FromResult(i > 0);
		}

		Task<bool> IRestaurationService.RemovePlat(int idPlat)
		{
			int i = PlatDb.RemoveAll(b => b.IdPlat == idPlat);
			return Task.FromResult(i > 0);
		}

		Task<Ingredient> IRestaurationService.UpdateIngredient(Ingredient ingredientToUpdate)
		{
			var _ingredient = IngredientDb.Find(b => b.IdIngredient == ingredientToUpdate.IdIngredient);
			_ingredient.nomIngredient = ingredientToUpdate.nomIngredient;
			_ingredient.prixMoyen = ingredientToUpdate.prixMoyen;

			return Task.FromResult(_ingredient);
		}

		Task<Menu> IRestaurationService.UpdateMenu(Menu menuToUpdate)
		{
			var _menu = MenuDb.Find(b => b.IdMenu == menuToUpdate.IdMenu);
			_menu.firstDayweek = menuToUpdate.firstDayweek;
			_menu.Plats = menuToUpdate.Plats;

			return Task.FromResult(_menu);

		}

		Task<Plat> IRestaurationService.UpdatePlat(Plat platToUpdate)
		{
			var _plat = PlatDb.Find(b => b.IdPlat == platToUpdate.IdPlat);
			_plat.nomPlat = platToUpdate.nomPlat;
			_plat.typePlat = platToUpdate.typePlat;
			_plat.Score = platToUpdate.Score;
			_plat.Ingredients = platToUpdate.Ingredients;

			return Task.FromResult(_plat);
		}
	}
}
