using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public class RestaurationService : IRestaurationService
	{
		private readonly HttpClient _httpClient;

		public RestaurationService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/");
		}

		public async Task<IEnumerable<Service>> GetAllServices()
		{
			if (AuthentificationService.Getinstance().IsLogged)
			{

				_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);


				var reponse = await _httpClient.GetAsync($"services");

				if (reponse.IsSuccessStatusCode)
				{
					using (var stream = await reponse.Content.ReadAsStreamAsync())
					{
						List<Service> menus = await JsonSerializer.DeserializeAsync<List<Service>>(stream,
							new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
						return menus;
					}
				}
				else
				{
					return null;
				}
			}


			return null;

		}
		


		public async Task<Service> GetServiceById(int idService)
		{
			if (AuthentificationService.Getinstance().IsLogged)
			{

				_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);


				var reponse = await _httpClient.GetAsync($"services/" + idService);

				if (reponse.IsSuccessStatusCode)
				{
					using (var stream = await reponse.Content.ReadAsStreamAsync())
					{
						Service service = await JsonSerializer.DeserializeAsync<Service>(stream,
							new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
						return service;
					}
				}
				else
				{
					return null;
				}
			}


			return null;

		}
	

	public async Task<Plat> GetPlatById(int idplat)
	{
		if (AuthentificationService.Getinstance().IsLogged)
		{

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);


			var reponse = await _httpClient.GetAsync($"plats/" + idplat);

			if (reponse.IsSuccessStatusCode)
			{
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					Plat plat = await JsonSerializer.DeserializeAsync<Plat>(stream,
						new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
					return plat;
				}
			}
			else
			{
				return null;
			}
		}


		return null;

	}


	public async Task<IEnumerable<Plat>> GetAllPlatsByType(int typePlat)
	{

		var reponse = await _httpClient.GetAsync($"plats/type/" + typePlat);

		if (reponse.IsSuccessStatusCode)
		{
			using (var stream = await reponse.Content.ReadAsStreamAsync())
			{
				List<Plat> plats = await JsonSerializer.DeserializeAsync<List<Plat>>(stream,
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
				return plats;
			}
		}
		else
		{
			return null;
		}



		}


	public async Task<Service> CreateMenu(Service newService)
		{
			try
			{
				var reponse = await _httpClient.PostAsJsonAsync($"services", newService);
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					return await JsonSerializer.DeserializeAsync<Service>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
		public async Task<Service> UpdateMenu(Service menuToUpdate)
		{
			try
			{
				if (menuToUpdate.IdService == null)
				{
					return null;
				}

				var reponse = await _httpClient.PostAsJsonAsync($"services/{menuToUpdate.IdService}", menuToUpdate);
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					return await JsonSerializer.DeserializeAsync<Service>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
				}
			}
			catch (Exception)
			{

				return null;
			}

		}
		public async Task<bool> RemoveMenu(Service menuToDelete)
		{
			if (menuToDelete.IdService != null)
			{
				try
				{
					var response = await _httpClient.DeleteAsync($"services/{menuToDelete.IdService}");
					if(response.IsSuccessStatusCode) 
						return true;
				}
				catch (Exception)
				{
					return false;

				}

			}
			return false;
		}

	}
}
