using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Responses
{
	/// <summary>
	/// login Response comportant le Token et le nom nécessaires pour l'acces aux données
	/// </summary>
	public class LoginResponse
	{
		public string AccessToken { get; set; }

		public string NOm { get; set; }

		public LoginResponse()
		{
				
		}


	}
}
