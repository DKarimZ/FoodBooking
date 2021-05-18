using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// Représente un objet de type plat
	/// </summary>
	public class Plat
	{
		/// <summary>
		/// identifiant du plat
		/// </summary>
		public int?  IdPlat { get; set; }

		/// <summary>
		/// nom du plat
		/// </summary>
		public string nomPlat { get; set; }

		/// <summary>
		/// type de plat (entrée, plat, dessert)
		/// </summary>
		public string typePlat { get; set; }

		/// <summary>
		/// Score de popularité du plat
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// Liste d'ingredients du plat
		/// </summary>
		public List<Ingredient> Ingredients { get; set; }

		/// <summary>
		/// Constructeur par défaut pour serialisation par l'API
		/// </summary>
		public Plat()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="idPlat"></param>
		/// <param name="nomPlat"></param>
		/// <param name="typePlat"></param>
		/// <param name="score"></param>
		/// <param name="ingredients"></param>
		public Plat(int? idPlat, string nomPlat, string typePlat, int score, List<Ingredient> ingredients
			)
		{
			IdPlat = idPlat;
			this.nomPlat = nomPlat;
			this.typePlat = typePlat;
			Score = score;
			Ingredients = ingredients;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Plat plat &&
				   IdPlat == plat.IdPlat &&
				   nomPlat == plat.nomPlat &&
				   typePlat == plat.typePlat &&
				   Score == plat.Score &&
				   EqualityComparer<List<Ingredient>>.Default.Equals(Ingredients, plat.Ingredients);
		}

		// Methode GetHashCode (Si besoin de la redéfinir)
		public override int GetHashCode()
		{
			return HashCode.Combine(IdPlat, nomPlat, typePlat, Score, Ingredients);
		}
	}
}
