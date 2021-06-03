using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Fixtures
{
	public class APIWebApplicationFactory : WebApplicationFactory<API.Startup>
	{
		public IConfiguration Configuration { get; private set; }

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureAppConfiguration(config =>
			{
				Configuration = new ConfigurationBuilder()
					.AddJsonFile("integrationsettings.json")
					.Build();

				config.AddConfiguration(Configuration);

			});
		}
	}
}
