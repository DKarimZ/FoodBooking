using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Requests
{
	public class pageRequestDTO
	{
        public int? page { get; set; }
        public int? maxPerPage { get; set; }

		public pageRequestDTO()
		{

		}

		public pageRequestDTO(int? page, int? maxPerPage)
		{
			this.page = page;
			this.maxPerPage = maxPerPage;
		}
	}
}
