using System;
using System.Collections.Generic;
using System.Text;

namespace BO.DTO
{
	public class EntryIOPDTO
	{
		public int IdIngredient {get;set; }
		public String NomIngredient { get; set; }

		public float PrixMoyen {get;set; }

		public float Quantite { get; set; }

		public EntryIOPDTO()
		{

		}

		public EntryIOPDTO(string nomIngredient, float quantite)
		{
			NomIngredient = nomIngredient;
			Quantite = quantite;
		}

		public EntryIOPDTO(int idIngredient, string nomIngredient, float prixMoyen, float quantite)
		{
			IdIngredient = idIngredient;
			NomIngredient = nomIngredient;
			PrixMoyen = prixMoyen;
			Quantite = quantite;
		}
	}
}
