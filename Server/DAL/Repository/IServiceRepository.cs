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
		Task<Plat> GetAsyncPlat0(int id);
		Task<Plat> GetAsyncPlat1(int id);
		Task<Plat> GetAsyncPlat2(int id);

		Task<Service> GetServiceByDateAndMidi(DateTime date, bool midi);
	}
}
