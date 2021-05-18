using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface ICommandeRepository
	{
		Task<IEnumerable<Commande>> GetAllAsync();
		Task<PageResponse<Commande>> GetAllAsync(PageRequest pageRequest);
		Task<Commande> GetAsync(int id);
		Task<Commande> InsertAsync(Commande commandeToCreate);
	}
}