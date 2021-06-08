using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public interface IRestaurationService
	{
		Task<Service> CreateMenu(Service newMenu);
		Task<IEnumerable<Service>> GetAllServices();
		Task<IEnumerable<Plat>> GetAllPlatsByType(int typePlat);

		Task<Service> GetServiceById(int idService);

		Task<Plat> GetPlatById(int idService);
		Task<bool> RemoveMenu(Service menuToDelete);
		Task<Service> UpdateMenu(Service menuToUpdate);
	}
}