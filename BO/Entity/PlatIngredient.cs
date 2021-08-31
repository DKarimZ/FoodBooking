using System.Collections.Generic;

namespace BO.Entity
{
	/// <summary>
	/// Entité correspondant à la table d'association entre plat et ingrédient
	/// </summary>
	public class PlatIngredient
	{
		/// <summary>
		/// Identifiant de l'entité PlatIngredient
		/// </summary>
		//int? IdPlatIngredient { get; set; }

		/// <summary>
		/// Ingredient correspondant à un plat
		/// </summary>
		public Ingredient Ingredient { get; set; }

		/// <summary>
		/// Quantite de chaque ingrédient
		/// </summary>
		public float Quantite { get; set; }

		/// <summary>
		/// constructeur par defaut de PlatIngredient
		/// </summary>

		public PlatIngredient()
		{

		}


		/// <summary>
		/// Constructeur full properties de platingredient
		/// </summary>
		/// <param name="ingredient"></param>
		/// <param name="quantite"></param>
		public PlatIngredient(Ingredient ingredient, float quantite)
		{
			Ingredient = ingredient;
			Quantite = quantite;
		}

		public override bool Equals(object obj)
		{
			return obj is PlatIngredient ingredient &&
				   EqualityComparer<Ingredient>.Default.Equals(Ingredient, ingredient.Ingredient) &&
				   Quantite == ingredient.Quantite;
		}

		public override int GetHashCode()
		{
			int hashCode = 1537735546;
			hashCode = hashCode * -1521134295 + EqualityComparer<Ingredient>.Default.GetHashCode(Ingredient);
			hashCode = hashCode * -1521134295 + Quantite.GetHashCode();
			return hashCode;
		}
	}
}
