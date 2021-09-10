using BO.DTO;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Interface du repository Ingredient implémentant les interfaces IGeneric Repository et IPageableRepository
	/// </summary>
	public interface IIngredientRepository : IgenericRepository<Ingredient>, IpageableRepository<Ingredient>
	{
		/// <summary>
		/// Methode permettant de récupérer tous les ingrédients d'un plat (en fonction de l'identifiant d'un plat)
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns></returns>
		Task<IngredientsofPlatDTO> GetAllIngredientsByIdPlat(int idPlat);


	}
}