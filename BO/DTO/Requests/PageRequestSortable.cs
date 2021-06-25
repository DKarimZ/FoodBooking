using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Requests
{
	/// <summary>
	/// représente un objet PagerequestSortable (page triable)
	/// </summary>
	public class PageRequestSortable : PageRequest
	{
		/// <summary>
		/// Score du livre
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// type de Plat (pour tri) : entrée, plat, dessert
		/// </summary>
		public TypePlat TypePlat { get; set; }

		/// <summary>
		/// Ingredient (pour tri)
		/// </summary>
		public Ingredient Ingredient { get; set; }

		/// <summary>
		/// Constructeur par defaut  pour serialisation (avec heritage de PageRequest)
		/// </summary>
		public PageRequestSortable() :base()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="score"></param>
		/// <param name="typePlat"></param>
		/// <param name="ingredient"></param>
		/// <param name="Page"></param>
		/// <param name="PageSize"></param>
		//public PageRequestSortable(int score, int typePlat, Ingredient ingredient, int Page, int PageSize) : base(Page, PageSize)
		//{
		//	Score = score;
		//	this.typePlat = typePlat;
		//	this.ingredient = ingredient;
		//}

		public PageRequestSortable(int score, int Page, int PageSize) : base(Page, PageSize)
		{
			Score = score;

		}

		public PageRequestSortable(TypePlat typePlat, int Page, int PageSize) : base(Page, PageSize)
		{
			TypePlat = typePlat;

		}

		public PageRequestSortable(Ingredient ingredient, int Page, int PageSize) : base(Page, PageSize)
		{
			Ingredient = ingredient;

		}

		public PageRequestSortable(int Page, int PageSize) : base(Page, PageSize)
		{

		}
	}
}
