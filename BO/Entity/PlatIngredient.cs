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
		Ingredient Ingredient { get; set; }

		/// <summary>
		/// Quantite de chaque ingrédient
		/// </summary>
		float Quantite { get; set; }

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


	}
}
