using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Interface du repository Client
	/// </summary>
	public interface IClientRepository : IgenericRepository<Client>, IpageableRepository<Client>
	{
		Task<Client> GetClientByUsernameAndPassword(string Nom, string password);
	}
}