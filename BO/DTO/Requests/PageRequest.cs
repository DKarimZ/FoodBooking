using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Requests
{
	/// <summary>
	/// represente un objet PageRequest
	/// </summary>
	public class PageRequest
	{
		/// <summary>
		/// Page courante
		/// </summary>
		public int Page { get; set; }

		/// <summary>
		/// Nombre maximum d'entités sur la page
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Constucteur par defaut pour serialisation par l'API
		/// </summary>
		public PageRequest()
		{
			
		}

		/// <summary>
		/// constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		public PageRequest(int page, int pageSize)
		{
			Page = page;
			PageSize = pageSize;
		}
	}
}
