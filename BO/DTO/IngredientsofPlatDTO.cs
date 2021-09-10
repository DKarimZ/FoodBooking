using BO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO.DTO
{
	public class IngredientsofPlatDTO
	{
		public List<EntryIOPDTO> ingredients {get;set; }

		public float quantite {get;set;}

		public IngredientsofPlatDTO(List<EntryIOPDTO> ingredients, float quantite)
		{
			this.ingredients = ingredients;
			this.quantite = quantite;
		}

		public IngredientsofPlatDTO()
		{

		}
	}
}
