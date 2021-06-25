using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Responses
{
	/// <summary>
	/// représente un objet PageResponseSortable
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PageResponseSortable<T> : PageResponse<T>
	{
		/// <summary>
		/// Score de popularité (pour tri)
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// constructeur par defaut
		/// </summary>
		public PageResponseSortable() :base()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="score"></param>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalRecords"></param>
		/// <param name="data"></param>
		public PageResponseSortable(int score, int page, int pageSize, int totalRecords, List<T> data) : base(page,pageSize,totalRecords,data)
		{
			Score = score;
		}
	}
}
