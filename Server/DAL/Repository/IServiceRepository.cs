using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Interface du repository Client implémentant les interfaces IGeneric Repository 
	/// </summary>
	public interface IServiceRepository : IgenericRepository<Service>
	{
		/// <summary>
		/// Méthode utilitaire permettant de récupérer le premier plat d'un service(entrée) en base de données
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Plat> GetAsyncPlat0(int id);

		/// <summary>
		/// Méthode permettant de récupérer le deuxième plat d'un service (plat) en base de données
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Plat> GetAsyncPlat1(int id);

		/// <summary>
		/// Méthode permettant de récupérer le troisième plat d'un service (dessert) en base de données
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Plat> GetAsyncPlat2(int id);

		/// <summary>
		/// Méthode permettant de récupérer un service en fonction d'une date et du moment de la journée (midi ou soir)
		/// </summary>
		/// <param name="date"></param>
		/// <param name="midi"></param>
		/// <returns></returns>
		Task<Service> GetServiceByDateAndMidi(DateTime date, bool midi);
	}
}
