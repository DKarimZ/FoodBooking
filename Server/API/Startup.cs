using System;
using System.Text;
using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using DocFx;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
				options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

			});

			//Versioning de l'API
			services.AddApiVersioning(config =>
			{
				config.ReportApiVersions = true;
			});

			//Documentation Client API

			services.AddVersionedApiExplorer(options =>
			{
				options.SubstituteApiVersionInUrl = true;
			});

			services.AddOpenApiDocument(config =>
			{
				config.DocumentName = "v1.0";
				config.PostProcess = document =>
				{
					document.Info.Version = "v1.0";
					document.Info.Title = "Public Api Connector";
					document.Info.Description = "A simple ASP.NET core web API";
					document.Info.Contact = new NSwag.OpenApiContact
					{
						Name = "Karimus D",
						Email = string.Empty,
						Url = ""
					};
					document.Info.License = new NSwag.OpenApiLicense
					{
						Name = "Use under LICX",
						Url = ""
					};
				};
				config.ApiGroupNames = new[] { "1.0" };
			});

			//JWT Authentification
			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidAudience = Configuration["JwtIssuer"],
						ValidIssuer = Configuration["JwtIssuer"],
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),

						ClockSkew = TimeSpan.Zero
					};

				});

			//Ajout de la méthode AddBLL (voir BLLExtension)
			services.AddBLL();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//Pipeline de l'application

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				
			}

			app.UseDocFx(config =>
		   {
			   config.rootPath = "/doc";
		   });

			// Liste des Middlewares du Pipeline

			//Middleware de génération du OpenAPIJson
			app.UseOpenApi(config =>
			{
				config.Path = "/api/doc/{documentName}/api.json";
			});

			//Midddleware de génération de l'interface utilisateur (en fonction du OpenApi.json)
			app.UseSwaggerUi3(config =>
			{
				config.DocumentPath = "/api/doc/{documentName}/api.json";
				config.Path = "/api/doc";
			});

			app.UseHttpsRedirection();

			app.UseRouting();


			//Add Authentification -> Error 401
			app.UseAuthentication();


			//Add AUthorisation -> Error 403
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
