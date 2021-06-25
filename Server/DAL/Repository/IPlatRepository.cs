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
		Task<IEnumerable<Plat>> GetAllThePlatsByTypePlat(int idtypePlat);

		Task<IEnumerable<Plat>> GetAllScoreAsync();

		Task<IEnumerable<Plat>> GetAllPLatswithIngredientX(int Idingredient);
	}
}
