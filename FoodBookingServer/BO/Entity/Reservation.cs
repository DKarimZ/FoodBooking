﻿using System;
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
		public List<Repas> Repass { get; set; }

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
		public Reservation(int? idReservation, DateTime dateReservation, List<Repas> repass
			)
		{
			IdReservation = idReservation;
			this.dateReservation = dateReservation;
			Repass = repass;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Reservation reservation &&
				   IdReservation == reservation.IdReservation &&
				   dateReservation == reservation.dateReservation &&
				   EqualityComparer<List<Repas>>.Default.Equals(Repass, reservation.Repass);
		}

		// Methode GetHashCode (Si besoin de la redéfinir)
		public override int GetHashCode()
		{
			return HashCode.Combine(IdReservation, dateReservation, Repass);
		}
	}
}
