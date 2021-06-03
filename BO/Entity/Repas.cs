using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// représente un objet de type repas
	/// </summary>
	public class Repas
	{
		/// <summary>
		/// Identifiant du repas
		/// </summary>
		public int IdRepas { get; set; }

		/// <summary>
		/// Service : Midi, Soir
		/// </summary>
		public string Service { get; set; }

		/// <summary>
		/// Formule : Entrée, plat ou plat Dessert ou entrée dessert
		/// </summary>
		public string Formule { get; set; }

		/// <summary>
		/// Liste des Menus
		/// </summary>
		public List<Service> Menus { get; set; }

		/// <summary>
		/// Constructeur par défaut pour serialisation par l'API
		/// </summary>
		public Repas()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="idRepas"></param>
		/// <param name="service"></param>
		/// <param name="formule"></param>
		/// <param name="menus"></param>
		public Repas(int idRepas, string service, string formule, List<Service> menus)
		{
			IdRepas = idRepas;
			Service = service;
			Formule = formule;
			Menus = menus;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Repas repas &&
				   IdRepas == repas.IdRepas &&
				   Service == repas.Service &&
				   Formule == repas.Formule &&
				   EqualityComparer<List<Service>>.Default.Equals(Menus, repas.Menus);
		}

		// Methode GetHashCode (Si besoin de la redéfinir)
		public override int GetHashCode()
		{
			return HashCode.Combine(IdRepas, Service, Formule, Menus);
		}
	}
}
