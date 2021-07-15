using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// représente un objet Reservation
	/// </summary>
	public class Reservation
	{
		/// <summary>
		/// Identifiant de la reservation
		/// </summary>
		public int? IdReservation { get; set; }

		/// <summary>
		/// date de la reservation
		/// </summary>
		public DateTime dateReservation { get; set; }

		/// <summary>
		/// Liste des repas de la reservation
		/// </summary>
		public List<Service>Services { get; set; }

		/// <summary>
		/// constructeur par defaut pour serialisation par l'API
		/// </summary>
		public Reservation()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="idReservation"></param>
		/// <param name="dateReservation"></param>
		/// <param name="repass"></param>
		public Reservation(int? idReservation, DateTime dateReservation, List<Service> services
			)
		{
			IdReservation = idReservation;
			this.dateReservation = dateReservation;
			Services = services;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Reservation reservation &&
				   IdReservation == reservation.IdReservation &&
				   dateReservation == reservation.dateReservation &&
				   EqualityComparer<List<Service>>.Default.Equals(Services, reservation.Services);
		}

		public override int GetHashCode()
		{
			int hashCode = 1121000728;
			hashCode = hashCode * -1521134295 + IdReservation.GetHashCode();
			hashCode = hashCode * -1521134295 + dateReservation.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<List<Service>>.Default.GetHashCode(Services);
			return hashCode;
		}

		// Methode GetHashCode (Si besoin de la redéfinir)

	}
}
