using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BO.DTO;
using BO.Entity;

namespace BLLC.Services
{
	public class FournisseurService : IFournisseurService
	{

		private readonly HttpClient _httpClient;

		public FournisseurService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/");
		}

		public async Task<CommandDTO> GetCommande()
		{

			if (AuthentificationService.Getinstance().IsLogged)
			{

				_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);


				var reponse = await _httpClient.GetAsync($"commandes/afficher");

				if (reponse.IsSuccessStatusCode)
				{
					using (var stream = await reponse.Content.ReadAsStreamAsync())
					{
						CommandDTO commande = await JsonSerializer.DeserializeAsync<CommandDTO>(stream,
							new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
						return commande;
					}
				}
				else
				{
					return null;
				}
			}


			return null;

		}

	}


}

