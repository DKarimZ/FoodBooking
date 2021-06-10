using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BO.DTO.Requests;
using BO.DTO.Responses;

namespace BLLC.Services
{
	public interface IRestaurationService
	{
		Task<Service> CreateMenu(Service newMenu);
		Task<Plat> CreatePlat(Plat newPlat);
		Task<IEnumerable<Service>> GetAllServices();
		Task<PageResponse<Plat>> GetAllPlats(PageRequest pagerequest);
		Task<PageResponse<Ingredient>> GetAllIngredients(PageRequest pagerequest);
		Task<IEnumerable<Plat>> GetAllPlatsByType(int typePlat);

		Task<Service> GetServiceById(int idService);

		Task<Plat> GetPlatById(int idService);
		Task<Ingredient> GetIngredientById(int idIngredient);
		Task<bool> RemoveMenu(Service menuToDelete);
		Task<Service> UpdateMenu(Service menuToUpdate);
	}
}