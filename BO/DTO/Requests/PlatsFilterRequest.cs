using System;
using System.Collections.Generic;
using System.Text;

namespace BO.DTO.Requests
{
	public class PlatsFilterRequest: PageRequest
	{
		public DateTime? date;
		public int? midi;
	}
	}
