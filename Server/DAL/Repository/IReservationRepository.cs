using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Interface du repository Reservation implémentant les interfaces IGeneric Repository et IPageableRepository
	/// </summary>
	public interface IReservationRepository : IgenericRepository<Reservation>, IpageableRepository<Reservation>
	{

	}
}
