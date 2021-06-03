using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API;
using System.Net.Http;
using IntegrationTest.Fixtures;

namespace IntegrationTest
{
	public abstract class Integrationtest : IClassFixture<APIWebApplicationFactory>
	{
		protected readonly WebApplicationFactory<Startup> _factory;
		protected readonly HttpClient _client;

		public Integrationtest(APIWebApplicationFactory factory)
		{
			_factory = factory;
			_client = factory.CreateClient();
		}
	}
}
