using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
			_httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
		}

		public async Task<IEnumerable<Menu>> GetAllMenus()
		{
			var reponse = await _httpClient.GetAsync($"menus");

			if (reponse.IsSuccessStatusCode)
			{
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					List<Menu> menus = await JsonSerializer.DeserializeAsync<List<Menu>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
					return menus;
				}
			}
			else
			{
				return null;
			}
		}
		//public async Task<Menu> GetMenuById(int IdMenu) 
		//{
		//
		//}
		public async Task<Menu> CreateMenu(Menu newMenu)
		{
			try
			{
				var reponse = await _httpClient.PostAsJsonAsync($"menus", newMenu);
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					return await JsonSerializer.DeserializeAsync<Menu>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
		public async Task<Menu> UpdateMenu(Menu menuToUpdate)
		{
			try
			{
				if (menuToUpdate.IdMenu == null)
				{
					return null;
				}

				var reponse = await _httpClient.PostAsJsonAsync($"menus/{menuToUpdate.IdMenu}", menuToUpdate);
				using (var stream = await reponse.Content.ReadAsStreamAsync())
				{
					return await JsonSerializer.DeserializeAsync<Menu>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
				}
			}
			catch (Exception)
			{

				return null;
			}

		}
		public async Task<bool> RemoveMenu(Menu menuToDelete)
		{
			if (menuToDelete.IdMenu != null)
			{
				try
				{
					await _httpClient.DeleteAsync($"menus/{menuToDelete.IdMenu}");
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
