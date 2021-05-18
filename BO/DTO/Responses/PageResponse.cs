using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Responses
{
	/// <summary>
	/// Objet de type PageResponse
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PageResponse<T>
	{
		/// <summary>
		/// page Courante
		/// </summary>
		public int Page { get; set; }

		/// <summary>
		/// nombre d'entités maimum par page
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// nombre total d'entités
		/// </summary>
		public int? TotalRecords { get; set; }

		/// <summary>
		/// nombre total de pages
		/// </summary>
		public int? TotalPages => TotalRecords.HasValue ? (int)Math.Ceiling(TotalRecords.Value / (double)PageSize) : (int?)null;

		/// <summary>
		/// Liste d'entités (de la page courante)
		/// </summary>
		public List<T> Data { get; set; }

		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		public PageResponse()
		{

		}

		/// <summary>
		/// Conctructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalRecords"></param>
		/// <param name="data"></param>
		public PageResponse(int page, int pageSize, int? totalRecords, List<T> data)
		{
			Page = page;
			PageSize = pageSize;
			TotalRecords = totalRecords;
			Data = data;
		}
	}
}
