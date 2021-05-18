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
		public string nomIngredient { get; set; }

		/// <summary>
		/// Prix moyen de l'ingredient
		/// </summary>
		public int prixMoyen { get; set; }

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
		public Ingredient(int? idIngredient, string nomIngredient, int prixMoyen)
		{
			IdIngredient = idIngredient;
			this.nomIngredient = nomIngredient;
			this.prixMoyen = prixMoyen;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Ingredient ingredient &&
				   IdIngredient == ingredient.IdIngredient &&
				   nomIngredient == ingredient.nomIngredient &&
				   prixMoyen == ingredient.prixMoyen;
		}

		// Methode GetHashCode (Si besoin de la redéfinir)
		public override int GetHashCode()
		{
			return HashCode.Combine(IdIngredient, nomIngredient, prixMoyen);
		}
	}
}
