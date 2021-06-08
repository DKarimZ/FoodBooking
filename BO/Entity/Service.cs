using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// Représente un objet Service
	/// </summary>
	public class Service
	{
		/// <summary>
		/// identifiant du Services
		/// </summary>
		public int? IdService { get; set; }

		/// <summary>
		/// Premier jour de la semaine ou est proposé le Service
		/// </summary>
		public Boolean Midi { get; set; }

		/// <summary>
		/// Liste des plats composants le Service
		/// </summary>
		/// 

		
		public DateTime dateJourservice { get; set; }


		public List<Plat> Plats { get; set; }

		/// <summary>
		/// Constructeur par défaut pour serialisation par l'API
		/// </summary>
		public Service()
		{

		}

		public Service(int? idService, bool midi, DateTime dateJourservice,List<Plat> plats)
		{
			IdService = idService;
			Midi = midi;
			this.dateJourservice = dateJourservice;
			Plats = plats;
		}

		public Service(int? idService, bool midi, DateTime dateJourservice)
		{
			IdService = idService;
			Midi = midi;
			this.dateJourservice = dateJourservice;
		}


		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Service service &&
				   IdService == service.IdService &&
				   Midi == service.Midi &&
				   dateJourservice == service.dateJourservice;
		}



		// Methode GetHashCode (Si besoin de la redéfinir)

		public override int GetHashCode()
		{
			return HashCode.Combine(IdService, Midi, dateJourservice);
		}




	}
}
