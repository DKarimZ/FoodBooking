using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO
{
	public class CommandDTO
	{
		public List<EntryCommandDTO> Entries { get; set; }

		public float TotalPrice { get; set; }

		public CommandDTO()
		{
			
		}

		public CommandDTO(List<EntryCommandDTO> entries, float totalPrice)
		{
			Entries = entries;
			TotalPrice = totalPrice;
		}



	}
}
