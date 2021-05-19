﻿using DAL.Repository;
using DAL.UOW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public static class DALExtension
	{

		public static IServiceCollection AddDAL(this IServiceCollection services)
		{
			services.AddScoped<DbSession>((services) => new DbSession(services.GetRequiredService<IConfiguration>(), "DefaultConnection"));

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			services.AddTransient<IMenuRepository, MenuRepository>();
			services.AddTransient<IPlatRepository, PlatRepository>();
			services.AddTransient<IReservationRepository, ReservationRepository>();
			services.AddTransient<IClientRepository, ClientRepository>();
			services.AddTransient<ICommandeRepository, CommandeRepository>();
			services.AddTransient<IIngredientRepository, IngredientRepository>();

			return services;

		}

	}
}