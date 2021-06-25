using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO
{
	public class EntryCommandDTO
	{
		public String NomIngredient { get; set; }

		public float Quantite { get; set; }

		public float Price { get; set; }

		public EntryCommandDTO()
		{
			
		}

		public EntryCommandDTO(String nomIngredient, float quantite, float price)
		{
			NomIngredient = nomIngredient;
			Quantite = quantite;
			Price = price;

		}
	}
}
