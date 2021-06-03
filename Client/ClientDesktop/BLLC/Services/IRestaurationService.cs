using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public interface IRestaurationService
	{
		Task<Service> CreateMenu(Service newMenu);
		Task<IEnumerable<Service>> GetAllServices();
		Task<bool> RemoveMenu(Service menuToDelete);
		Task<Service> UpdateMenu(Service menuToUpdate);
	}
}