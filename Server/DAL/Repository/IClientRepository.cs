using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Interface du repository Client implémentant les interfaces IGeneric Repository et IPageableRepository
	/// </summary>
	public interface IClientRepository : IgenericRepository<Client>, IpageableRepository<Client>
	{
		/// <summary>
		/// Methode permettant de recuperer un client en fonction de son nom et de son mot de passe en base de données
		/// </summary>
		/// <param name="Nom"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		Task<Client> GetClientByUsernameAndPassword(string Nom, string password);

		
	}
}