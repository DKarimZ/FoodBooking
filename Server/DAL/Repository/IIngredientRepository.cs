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
		
	}
}