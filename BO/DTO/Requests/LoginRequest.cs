using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Requests
{
	/// <summary>
	/// DTO loginRequest comportant les informations nécessaires à l'authentification
	/// </summary>
	public class LoginRequest
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password{ get; set; }

		public LoginRequest()
		{

		}
	}
}
