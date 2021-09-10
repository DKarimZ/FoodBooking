using API;
using BO.Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Requests;
using BO.DTO.Responses;
using Xunit;

namespace IntegrationTest.Fixtures
{
	public class MenuControllerIntegrationTest : Integrationtest
	{
		public MenuControllerIntegrationTest(APIWebApplicationFactory factory) : base(factory) { }


		[Fact]
		public async Task GetMenuById_Should_be_OK()
		{
			Service expected = new Service()
			{
				IdService = 1,
				Midi = false,
				dateJourservice = new DateTime(2021, 12, 13)

			};
			var httpResponse = await _client.PostAsJsonAsync<LoginRequest>("api/v1/account/login", new LoginRequest(){Username = "Riviere", Password = "Pass"});

			var loginResponse = await httpResponse.Content.ReadFromJsonAsync<LoginResponse>();

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);

			var response = await _client.GetFromJsonAsync<Service>("api/v1/services/1");

			Assert.Equal(response, expected);

			_client.DefaultRequestHeaders.Authorization = null;



		}

		[Fact]
		public async Task getMenuById_Should_Be_notFound()
		{


			var response = await _client.GetAsync("api/v1/services/178");

			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);



		}

		[Fact]
		public async Task createSameMenuWithSameDateANdMidi_Should_Be_notWorking()
		{
			var servceiTest = new Service { dateJourservice=new DateTime(2021-09-18),Midi = true};
			var response = await _client.PostAsJsonAsync("api/v1/services/",servceiTest );

			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


		}

	}
}
