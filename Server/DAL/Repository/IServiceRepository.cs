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
	
	}
}
