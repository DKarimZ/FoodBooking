using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Responses;
using BO.Entity;
using DAL.Repository;
using DAL.UOW;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services
{
	 class AccountService : IAccountService
	{
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _unitofwork;

		public AccountService(IConfiguration configuration, IUnitOfWork _unitofwork)
		{
			_configuration = configuration;
			this._unitofwork = _unitofwork;
		}

		public async Task<LoginResponse> Login(string nom, string password)
		{
			//TODO : Rechercher dans la base de données l'utilisateer
			var clientRepository = _unitofwork.GetRepository<IClientRepository>();
			var client =await  clientRepository.GetClientByUsernameAndPassword(nom, password);
			if (client != null)
			{

				var loginResponse = new LoginResponse()
				{
					NOm = nom,
					AccessToken = GenerateJwtToken(client)

				};

				return loginResponse;
			}
			else
			{
				return null;
			}
		}

		private string GenerateJwtToken(Client client)
		{
			// Add Users infos
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, client.nom),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, client.nom),
				



			};
			
			//Add Role
			
			claims.Add(new Claim(ClaimTypes.Role, client.role));

				//Signing key
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			//Expiration Time
			var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

			//Create JWT Token object
			var token = new JwtSecurityToken
			(
				_configuration["JwtIssuer"],
				_configuration["JwtIssuer"],
				claims,
				expires: expires,
				signingCredentials: creds
			);

			//Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.
			return new JwtSecurityTokenHandler().WriteToken(token);

		}

	}

}

