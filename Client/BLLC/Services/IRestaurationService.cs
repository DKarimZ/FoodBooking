using System;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.DTO;

namespace BLLC.Services
{
	/// <summary>
	/// Ce service permet de lister l'ensemble des fonctionnalités en lien avec la restauration (plats, ingredients,service) utiles au niveau de l'application desktop
	/// </summary>
	public interface IRestaurationService
	{
		/// <summary>
		/// Cette méthode permet de créer un service
		/// </summary>
		/// <param name="newMenu"></param>
		/// <returns></returns>
		Task<Service> CreateMenu(Service newMenu);

		/// <summary>
		/// Cette méthode permet de créer un plat 
		/// </summary>
		/// <param name="newPlat"></param>
		/// <returns></returns>
		Task<Plat> CreatePlat(Plat newPlat);

		/// <summary>
		/// Cette méthode permet de récupérer la liste de tous les services
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Service>> GetAllServices();

		/// <summary>
		/// Cette méthode permet de récupérer la lsite des plats à l'aide d'un pageRequest et permet la pagination
		/// </summary>
		/// <param name="pagerequest"></param>
		/// <returns></returns>
		Task<PageResponse<Plat>> GetAllPlats(PageRequest pagerequest);

		/// <summary>
		/// Cette méthode permet de récupérer tous les ingrédients existants au niveau du restaurant
		/// </summary>
		/// <param name="pagerequest"></param>
		/// <returns></returns>
		Task<PageResponse<Ingredient>> GetAllIngredients(PageRequest pagerequest);

		/// <summary>
		/// Cette méthode permet de récupérer tous les plats servis à une date et un moment donnée de la journée (midi ou soir)
		/// </summary>
		/// <param name="date"></param>
		/// <param name="midi"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPlatsByDateServiceandMidi(DateTime date, bool midi);


		/// <summary>
		/// Cette méthode permet ed récupérer tous les plats comportant un ingrédient dont l'identifiante st fourni en paramètre
		/// </summary>
		/// <param name="IdIngredient"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPlatsByIngredient(int IdIngredient);


		/// <summary>
		/// Cette méthode permet de récupérer tous les plats d'un type précis (entrée, plat ou dessert (1,2,3)
		/// </summary> ou 
		/// <param name="typePlat"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPlatsByType(int typePlat);

		/// <summary>
		/// Cette méthode permet de récupérer tous les ingrédients qui composent un plat en fonction de l'identifiant du plat
		/// </summary>
		/// <param name="IdPlat"></param>
		/// <returns></returns>
		Task<IngredientsofPlatDTO> GetAllIngredientsByIdPlat(int IdPlat);

		/// <summary>
		/// Cette méthode permet de récupérer tous les plats et de les trier par popularité
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPlatsByPopularity();

		/// <summary>
		/// Cette méthode permeyt de récupérer un service complet à partir de son indetifiant
		/// </summary>
		/// <param name="idService"></param>
		/// <returns></returns>
		Task<Service> GetServiceById(int idService);

		/// <summary>
		/// Cette méthode permet de récupérer un plat en fonction de son identifiant
		/// </summary>
		/// <param name="idService"></param>
		/// <returns></returns>
		Task<Plat> GetPlatById(int idService);

		/// <summary>
		/// Cette méthode permet de récupérer un ingrédien ten fonction de son identofiant
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <returns></returns>
		Task<Ingredient> GetIngredientById(int idIngredient);

		/// <summary>
		/// Cette méthode permetd esupprimer un service 
		/// </summary>
		/// <param name="menuToDelete"></param>
		/// <returns></returns>
		Task<bool> RemoveMenu(Service menuToDelete);

		/// <summary>
		/// Cette méthode permet de supprimer un plat passé en paramètres
		/// </summary>
		/// <param name="platToDelete"></param>
		/// <returns></returns>
		Task<bool> removePlat(Plat platToDelete);

		/// <summary>
		/// Cette méthode permet de mettre à jour un service passé en paramètre
		/// </summary>
		/// <param name="menuToUpdate"></param>
		/// <returns></returns>
		Task<Service> UpdateMenu(Service menuToUpdate);

		/// <summary>
		/// Cette méthode permet de mettre à jour un plat passé en paramètre
		/// </summary>
		/// <param name="platToUpdate"></param>
		/// <returns></returns>
		Task<Plat> UpdatePlat(Plat platToUpdate);
	}
}