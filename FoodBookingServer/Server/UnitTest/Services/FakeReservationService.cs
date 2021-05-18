using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{
	class FakeReservationService
	{
		public List<Reservation> reservationDb = new List<Reservation>()
		{
			new Reservation(3,new DateTime(2021,10,15),

		};

		Task<List<Reservation>> GetAllReservations()
		{
			return Task.FromResult(reservationDb);
		}

		Task<Reservation> GetReservationById(int IdReservation)
		{

		}

		Task<Reservation> CreateReservation(Reservation newReservation)
		{

		}

		Task<Reservation> ModifyReservation(Reservation reservationToUpdate)
		{

		}

		Task<bool> removeReservation(int Idreservation)
		{

		}




	}
}
