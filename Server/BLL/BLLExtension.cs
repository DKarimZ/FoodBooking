using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
	/// <summary>
	/// Permet d'ajouter des méthodes d'extension à la Bibliothèque métier (BLL)
	/// </summary>
	public static class BLLExtension
	{

		/// <summary>
		/// pemret d'ajouter toute une collection de services
		/// </summary>
		/// <param name="services"></param>
		/// <returns>retourne une collection de services</returns>
		public static IServiceCollection AddBLL(this IServiceCollection services)
		{
			//Ajout de la méthode d'extension de la DAL
			services.AddDAL();

			//Ajout des différents services de la BLL
			//Tansient => une  nouvelle instance de chaque service est créé à chaque demande
			services.AddTransient<IReservationService, ReservationService>();
			services.AddTransient<IRestaurationService, RestaurationService>();
			services.AddTransient<IFournisseurService, FournisseurService>();
			services.AddTransient<IAccountService, AccountService>();

			return services;

		}

	}
}
