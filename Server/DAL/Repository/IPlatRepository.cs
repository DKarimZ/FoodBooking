using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Requests;

namespace DAL.Repository
{

	/// <summary>
	/// Interface du repository Plat implémentant les interfaces IGenericRepository et IPageableRepository et ISortableRepository
	/// </summary>
	public interface IPlatRepository : IgenericRepository<Plat> , IpageableRepository<Plat> , ISortableRepository<Plat>
	{
		/// <summary>
		/// Méthode permettant de récupérer tous les plats par type dans la base de données
		/// </summary>
		/// <param name="idtypePlat"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllThePlatsByTypePlat(int idtypePlat);

		/// <summary>
		/// Méthode permettant de récupérer tous les plats par popularité dans la base de données
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllScoreAsync();

		/// <summary>
		/// Méthode permettant de récupérer tous les plats comportant un ingrédient en fonction del'identifiant de l'ingrédient et cela en base de données
		/// </summary>
		/// <param name="Idingredient"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPLatswithIngredientX(int Idingredient);

		/// <summary>
		/// Méthode permettant de récupérer tous les plats correspondant à une date et midi ou soir et cela en base de données
		/// </summary>
		/// <param name="date"></param>
		/// <param name="midi"></param>
		/// <returns></returns>
		Task<IEnumerable<Plat>> GetAllPlatsByDayAndService(DateTime date, bool midi);
	}
}
