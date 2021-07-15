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
		public int IdService { get; set; }


		/// <summary>
		/// Premier jour de la semaine ou est proposé le Service
		/// </summary>
		public Boolean Midi { get; set; }

		
		/// <summary>
		/// Date correspondant au jour du service
		/// </summary>
		public DateTime dateJourservice { get; set; }


		/// <summary>
			/// Liste des plats composants le Service
			/// </summary>
			///
		public List<Plat> Plats { get; set; }


		/// <summary>
		/// Constructeur par défaut pour serialisation par l'API
		/// </summary>
		public Service()
		{

		}


		/// <summary>
		/// Constructeur Full properties de l'entité service
		/// </summary>
		/// <param name="idService"></param>
		/// <param name="midi"></param>
		/// <param name="dateJourservice"></param>
		/// <param name="plats"></param>
		public Service(int idService, bool midi, DateTime dateJourservice,List<Plat> plats)
		{
			IdService = idService;
			Midi = midi;
			this.dateJourservice = dateJourservice;
			Plats = plats;

			foreach (Plat plat in Plats)
			{
				plat.Score++;
			}

		}


		/// <summary>
		/// Constructeur Service presque full proprties - sauf la liste de plats
		/// </summary>
		/// <param name="idService"></param>
		/// <param name="midi"></param>
		/// <param name="dateJourservice"></param>
		public Service(int idService, bool midi, DateTime dateJourservice)
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

		public override int GetHashCode()
		{
			int hashCode = 717657432;
			hashCode = hashCode * -1521134295 + IdService.GetHashCode();
			hashCode = hashCode * -1521134295 + Midi.GetHashCode();
			hashCode = hashCode * -1521134295 + dateJourservice.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<List<Plat>>.Default.GetHashCode(Plats);
			return hashCode;
		}


		// Methode GetHashCode (Si besoin de la redéfinir)





	}
}
