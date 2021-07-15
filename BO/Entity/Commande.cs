using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// Représente un objet commande
	/// </summary>
	public class Commande
	{
		/// <summary>
		/// Identifiant de la commande
		/// </summary>
		//public int? IdCommande { get; set; }

		/// <summary>
		/// Jour de la commande
		/// </summary>
		public DateTime jourCommande { get; }

		/// <summary>
		/// liste d'ingrédients de la commande
		/// </summary>
		public Ingredient Ingredients { get; set; }

		public float Quantite { get; set; }

		/// <summary>
		/// Constructeur par défaut pour sérialisation par l'API
		/// </summary>
		public Commande()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec tous les paramètres
		/// </summary>
		/// <param name="idCommande"></param>
		/// <param name="ingredients"></param>
		public Commande( Ingredient ingredients, float quantite)
		{
			jourCommande = DateTime.Now;
			Ingredients = ingredients;
			Quantite = quantite;
		}

		public override bool Equals(object obj)
		{
			return obj is Commande commande &&
				   jourCommande == commande.jourCommande &&
				   EqualityComparer<Ingredient>.Default.Equals(Ingredients, commande.Ingredients) &&
				   Quantite == commande.Quantite;
		}

		public override int GetHashCode()
		{
			int hashCode = 243418636;
			hashCode = hashCode * -1521134295 + jourCommande.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Ingredient>.Default.GetHashCode(Ingredients);
			hashCode = hashCode * -1521134295 + Quantite.GetHashCode();
			return hashCode;
		}


		// Methode Equals (Si besoin de la redéfinir)

		//public override bool Equals(object obj)
		//{
		//	return obj is Commande commande &&
		//		   IdCommande == commande.IdCommande &&
		//		   EqualityComparer<List<Ingredient>>.Default.Equals(Ingredients, commande.Ingredients);
		//}

		// Methode GetHashCode (Si besoin de la redéfinir)

		//public override int GetHashCode()
		//{
		//	return HashCode.Combine(IdCommande, Ingredients);
		//}
	}
}
