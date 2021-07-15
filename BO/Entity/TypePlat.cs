using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// Entité correspondant au type de plat (entrée, plat ou dessert)
	/// </summary>
	public class TypePlat
	{

		/// <summary>
		/// Identifinat du type de plat - 1, 2 ou 3
		/// </summary>
		public int? IdTypePlat { get; set; }

		/// <summary>
		/// Libelle - entree, plat ou dessert
		/// </summary>
		public string libelle { get; set; }

		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		public TypePlat()
		{

		}

		/// <summary>
		/// Constructeur avec toutes les propriétés
		/// </summary>
		/// <param name="idTypePlat"></param>
		/// <param name="libelle"></param>
		public TypePlat(int? idTypePlat, string libelle)
		{
			IdTypePlat = idTypePlat;
			this.libelle = libelle;
		}

		//Methode Equals pour un eventuel override
		public override bool Equals(object obj)
		{
			return obj is TypePlat plat &&
				   IdTypePlat == plat.IdTypePlat &&
				   libelle == plat.libelle;
		}

		public override int GetHashCode()
		{
			int hashCode = -932488181;
			hashCode = hashCode * -1521134295 + IdTypePlat.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(libelle);
			return hashCode;
		}
		//Methoode GetHashCode pour réécriture


	}
}
