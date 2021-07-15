using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// représente un objet ingredient
	/// </summary>
	public class Ingredient
	{
		/// <summary>
		/// Identifiant de l'ingredient
		/// </summary>
		public int? IdIngredient { get; set; }

		/// <summary>
		/// Nom de l'ingredient
		/// </summary>
		public string NomIngredient { get; set; }

		/// <summary>
		/// Prix moyen de l'ingredient
		/// </summary>
		public float PrixMoyen { get; set; }

		/// <summary>
		/// Constructeur par defaut pour serialisation par l'API
		/// </summary>
		public Ingredient()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <param name="nomIngredient"></param>
		/// <param name="prixMoyen"></param>
		public Ingredient(int? idIngredient, string nomIngredient, float prixMoyen)
		{
			IdIngredient = idIngredient;
			this.NomIngredient = nomIngredient;
			this.PrixMoyen = prixMoyen;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Ingredient ingredient &&
				   IdIngredient == ingredient.IdIngredient &&
				   NomIngredient == ingredient.NomIngredient &&
				   PrixMoyen == ingredient.PrixMoyen;
		}

		public override int GetHashCode()
		{
			int hashCode = -1431934069;
			hashCode = hashCode * -1521134295 + IdIngredient.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomIngredient);
			hashCode = hashCode * -1521134295 + PrixMoyen.GetHashCode();
			return hashCode;
		}

		// Methode GetHashCode (Si besoin de la redéfinir)

	}
}
