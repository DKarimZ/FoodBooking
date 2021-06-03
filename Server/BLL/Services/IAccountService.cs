using System.Threading.Tasks;
using BO.DTO.Responses;

namespace BLL.Services
{
	public interface IAccountService
	{
		Task<LoginResponse> Login(string nom, string password);
	}
}