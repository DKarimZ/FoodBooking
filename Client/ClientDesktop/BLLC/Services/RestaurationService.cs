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
			if (AuthentificationService.Getinstance().IsLogged) {

				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);


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
		//public async Task<Menu> GetMenuById(int IdMenu) 
		//{
		//
		//}
		public async Task<Service> CreateMenu(Service newMenu)
		{
			try
			{
				var reponse = await _httpClient.PostAsJsonAsync($"menus", newMenu);
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

				var reponse = await _httpClient.PostAsJsonAsync($"menus/{menuToUpdate.IdService}", menuToUpdate);
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
					await _httpClient.DeleteAsync($"menus/{menuToDelete.IdService}");
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
