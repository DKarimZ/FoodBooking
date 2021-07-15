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
		public string Nom { get; set; }

		/// <summary>
		/// type de plat (entrée, plat, dessert)
		/// </summary>
		public TypePlat typePlat { get; set; }

		/// <summary>
		/// Score de popularité du plat
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// Liste d'ingredients du plat
		/// </summary>
		public List<PlatIngredient> PlatIngredient { get; set; }

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
		public Plat(int? idPlat, string nomPlat, TypePlat typePlat, int score, List<PlatIngredient> platIngredients
			)
		{
			IdPlat = idPlat;
			this.Nom = nomPlat;
			this.typePlat = typePlat;
			Score = score;
			PlatIngredient = platIngredients;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Plat plat &&
				   IdPlat == plat.IdPlat &&
				   Nom == plat.Nom &&
				   typePlat == plat.typePlat &&
				   Score == plat.Score &&
				   EqualityComparer<List<PlatIngredient>>.Default.Equals(PlatIngredient, plat.PlatIngredient);
		}

		public override int GetHashCode()
		{
			int hashCode = -1500760494;
			hashCode = hashCode * -1521134295 + IdPlat.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
			hashCode = hashCode * -1521134295 + EqualityComparer<TypePlat>.Default.GetHashCode(typePlat);
			hashCode = hashCode * -1521134295 + Score.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<List<PlatIngredient>>.Default.GetHashCode(PlatIngredient);
			return hashCode;
		}

		// Methode GetHashCode (Si besoin de la redéfinir)

	}
}
