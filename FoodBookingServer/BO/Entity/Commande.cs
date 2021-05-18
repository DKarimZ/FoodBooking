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
		public int? IdCommande { get; set; }

		/// <summary>
		/// Jour de la commande
		/// </summary>
		public DateTime jourCommande { get; }

		/// <summary>
		/// liste d'ingrédients de la commande
		/// </summary>
		public List<Ingredient> Ingredients { get; set; }

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
		public Commande(int? idCommande, List<Ingredient> ingredients)
		{
			jourCommande = DateTime.Now;
			IdCommande = idCommande;
			Ingredients = ingredients;
		}

		// Methode Equals (Si besoin de la redéfinir)

		public override bool Equals(object obj)
		{
			return obj is Commande commande &&
				   IdCommande == commande.IdCommande &&
				   EqualityComparer<List<Ingredient>>.Default.Equals(Ingredients, commande.Ingredients);
		}

		// Methode GetHashCode (Si besoin de la redéfinir)

		public override int GetHashCode()
		{
			return HashCode.Combine(IdCommande, Ingredients);
		}
	}
}
