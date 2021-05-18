using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	/// <summary>
	/// interface des services liés à la restauration : Menu, plat, ingredient
	/// </summary>
	public interface IRestaurationService
	{
		//Services liés aux menus
		#region Menu

		/// <summary>
		/// Permet de récupérer la liste des menus
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>retourne la liste des menus</returns>
		Task<List<Menu>> GetAllMenus();

		/// <summary>
		/// Permet de récupérer un menu par son Identifiant
		/// </summary>
		/// <param name="IdMenu"></param>
		/// <returns>retourne un menu en particulier ou null si non touvé</returns>
		Task<Menu> GetMenuById(int IdMenu);

		/// <summary>
		/// Permet de créer un menu
		/// </summary>
		/// <param name="newMenu"></param>
		/// <returns>Retourne le nouveau menu</returns>
		Task<Menu> CreateMenu(Menu newMenu);

		/// <summary>
		/// Permet de mettre à jour un menu
		/// </summary>
		/// <param name="menuToUpdate"></param>
		/// <returns>retourne le menu mis a jour</returns>
		Task<Menu> UpdateMenu(Menu menuToUpdate);

		/// <summary>
		/// Permet de supprimer un menu
		/// </summary>
		/// <param name="IdMenu"></param>
		/// <returns>retoune un boolean en fonction du succes de la methode</returns>
		Task<bool> RemoveMenu(int IdMenu);

		#endregion
		//Services liés aux plats
		#region Plat

		/// <summary>
		/// Permet de récupérer la liste des plats
		/// </summary>
		/// <returns>retourne la liste des plats</returns>
		Task<PageResponse<Plat>> GetAllPlats(PageRequest pageRequest);

		/// <summary>
		/// permet de récupérer un plat en fonction de son identifiant
		/// </summary>
		/// <param name="IdPlat"></param>
		/// <returns>retourne un plat en particulier</returns>
		Task<Plat> GetPlatById(int IdPlat);

		/// <summary>
		/// Permet de créer un nouveau plat
		/// </summary>
		/// <param name="newPlat"></param>
		/// <returns> retourne le nouveau plat</returns>
		Task<Plat> CreatePlat(Plat newPlat);

		/// <summary>
		/// Permet de mettre à jour le repas
		/// </summary>
		/// <param name="platToUpdate"></param>
		/// <returns>retourne le repas mis à jour</returns>
		Task<Plat> UpdatePlat(Plat platToUpdate);

		/// <summary>
		/// Permet de supprimer un plat
		/// </summary>
		/// <param name="IdPlat"></param>
		/// <returns>retourne un boolean en fonction du succès de la suppression</returns>
		Task<bool> RemovePlat(int IdPlat);
		#endregion
		//Services liés aux ingrédients
		#region Ingredient
		/// <summary>
		/// Permet de récupérer la liste des ingrédients
		/// </summary>
		/// <returns>retourne la liste des ingrédients</returns>
		Task<PageResponse<Ingredient>> GetAllIngredients(PageRequest pageRequest);

		/// <summary>
		/// Permet de récupérer un ingrédient en fonction de son identifiant
		/// </summary>
		/// <param name="IdIngredient"></param>
		/// <returns>retourne un ingrédient en particulier</returns>
		Task<Ingredient> GetIngredientById(int IdIngredient);

		/// <summary>
		/// Permet de créer un nouvel ingrédient
		/// </summary>
		/// <param name="newIngredient"></param>
		/// <returns>retourne le nouvel ingrédient</returns>
		Task<Ingredient> CreateIngredient(Ingredient newIngredient);

		/// <summary>
		/// Permet de mettre à jour un ingrédient
		/// </summary>
		/// <param name="ingredientToUpdate"></param>
		/// <returns>retourne l'ingrédient mis à jour</returns>
		Task<Ingredient> UpdateIngredient(Ingredient ingredientToUpdate);

		/// <summary>
		/// Permet de supprimer un ingrédient
		/// </summary>
		/// <param name="IdIngredient"></param>
		/// <returns>retroune un booléen en fonction du succès de la suppression</returns>
		Task<bool> RemoveIngredient(int IdIngredient);

		#endregion
	}
}
