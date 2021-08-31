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

	/// <summary>
	/// Permet de fournir les services liés àà l'authentification
	/// </summary>
	 class AccountService : IAccountService
	{
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _unitofwork;

		public AccountService(IConfiguration configuration, IUnitOfWork _unitofwork)
		{
			_configuration = configuration;
			this._unitofwork = _unitofwork;
		}


		/// <summary>
		/// methode de service permettant de s'identifier
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="password"></param>
		/// <returns>Retoune le dto loginreponse composé du nom et du Token</returns>
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


		/// <summary>
		/// Methode de service permettant de générer le token jwt à partir duclient
		/// </summary>
		/// <param name="client"></param>
		/// <returns>Retourne  le token généré</returns>
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
			claims.Add(new Claim("clientId", client.IdClient.ToString()));

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

