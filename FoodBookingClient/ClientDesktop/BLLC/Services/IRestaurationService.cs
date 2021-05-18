using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public interface IRestaurationService
	{
		Task<Menu> CreateMenu(Menu newMenu);
		Task<IEnumerable<Menu>> GetAllMenus();
		Task<bool> RemoveMenu(Menu menuToDelete);
		Task<Menu> UpdateMenu(Menu menuToUpdate);
	}
}