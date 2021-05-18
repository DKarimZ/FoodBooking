using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface IIngredientRepository : IgenericRepository<Ingredient>, IpageableRepository<Ingredient>
	{
		
	}
}