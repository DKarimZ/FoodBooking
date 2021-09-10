using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BO.DTO;

namespace DAL.Repository
{
	public interface ICommandeRepository
	{
		/// <summary>
		/// Méthode permettant de récupérer touts les commandes
		/// </summary>
		/// <returns>Une liste de Commandes</returns>
		Task<IEnumerable<Commande>> GetAllAsync();

		/// <summary>
		/// Méthode permettnt de récupérer toutes les commandes avec commme paramètres un pageRequest en en retour in PageResponse
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns></returns>
		Task<PageResponse<Commande>> GetAllAsync(PageRequest pageRequest);

		/// <summary>
		/// Permet de récupérer la commande
		/// </summary>
		/// <returns></returns>
		Task<CommandDTO> GetAsync();
	
	}
}