using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// Représente un objet Menu
	/// </summary>
	public class Menu 
	{
		/// <summary>
		/// identifiant du menu
		/// </summary>
		public int? IdMenu { get; set; }

		/// <summary>
		/// Premier jour de la semaine ou est proposé le menu
		/// </summary>
		public string firstDayweek { get; set; }

		/// <summary>
		/// Liste des plats composants le menu
		/// </summary>
		public Plat Plats { get; set; }

		/// <summary>
		/// Constructeur par défaut pour serialisation par l'API
		/// </summary>
		public Menu()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="firstDayweek"></param>
		/// <param name="plats"></param>
		public Menu(int? idMenu, string firstDayweek, Plat plats)
		{
			IdMenu = idMenu;
			this.firstDayweek = firstDayweek;
			Plats = plats;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Menu menu &&
				   IdMenu == menu.IdMenu &&
				   firstDayweek == menu.firstDayweek &&
				   EqualityComparer<Plat>.Default.Equals(Plats, menu.Plats);
		}

		// Methode GetHashCode (Si besoin de la redéfinir)

		public override int GetHashCode()
		{
			return HashCode.Combine(IdMenu, firstDayweek, Plats);
		}
	}
}
