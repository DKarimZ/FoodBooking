using System.Threading.Tasks;
using BO.DTO.Responses;

namespace BLL.Services
{
	/// <summary>
	/// Interface du service d'authentification
	/// </summary>
	public interface IAccountService
	{
		Task<LoginResponse> Login(string nom, string password);
	}
}