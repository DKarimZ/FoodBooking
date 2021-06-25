using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLC.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;

namespace ClientDesktop
{
	public partial class fenetreTriPlat : Form
	{

		private readonly IRestaurationService _restaurationService;
		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourcePlatsTriesParType = new BindingSource();
		private BindingSource bindingSourcePlatsTriesParpopularite = new BindingSource();
		private BindingSource bindingSourcePlatsTriesParIngredient = new BindingSource();

		public fenetreTriPlat()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			LoadTriParType();
		}


		public void refresh()
		{
			dGVTripartype.Refresh();
			
		}


		public async void LoadTriParType()
		{
			PageRequest pagerequest = new PageRequest(page: 1, 30);

			Task<PageResponse<Plat>> platsTask = _restaurationService.GetAllPlats(pagerequest);
			var plats = await platsTask;
			bindingSourcePlats.DataSource = plats.Data;


			dGVTripartype.DataSource = bindingSourcePlats;
		}

		private async void btnnTriEntree_Click(object sender, EventArgs e)
		{
			Task<IEnumerable<Plat>> platstriespartypeTask = _restaurationService.GetAllPlatsByType(1);
			var platstries = await platstriespartypeTask;
			bindingSourcePlatsTriesParType.DataSource = platstries;


			dGVTripartype.DataSource = bindingSourcePlatsTriesParType;
			refresh();
				
			
		}

		private async void btnTriPlats_Click(object sender, EventArgs e)
		{
			Task<IEnumerable<Plat>> platstriespartypeTask = _restaurationService.GetAllPlatsByType(2);
			var platstries = await platstriespartypeTask;
			bindingSourcePlatsTriesParType.DataSource = platstries;


			dGVTripartype.DataSource = bindingSourcePlatsTriesParType;
			refresh();

		}

		private async void btnTridessert_Click(object sender, EventArgs e)
		{
			Task<IEnumerable<Plat>> platstriespartypeTask = _restaurationService.GetAllPlatsByType(3);
			var platstries = await platstriespartypeTask;
			bindingSourcePlatsTriesParType.DataSource = platstries;


			dGVTripartype.DataSource = bindingSourcePlatsTriesParType;
			refresh();


		}

		private async void btnTriAscendant_Click(object sender, EventArgs e)
		{

			

			Task<IEnumerable<Plat>> platstriesparpopulariteTask = _restaurationService.GetAllPlatsByPopularity();
			var platstriesparpopularite = await platstriesparpopulariteTask;

			bindingSourcePlatsTriesParpopularite.DataSource = platstriesparpopularite;

			dGVTriPopularite.DataSource = bindingSourcePlatsTriesParpopularite;

		}

		private async  void btnTriParIngredient_Click(object sender, EventArgs e)
		{
			int IdIngredient = Convert.ToInt16(txtBoxNomIngredient.Text);

			Task<IEnumerable<Plat>> platstriespringredientTask = _restaurationService.GetAllPlatsByIngredient(IdIngredient);
			var platstriesparingredient = await platstriespringredientTask;

			bindingSourcePlatsTriesParIngredient.DataSource = platstriesparingredient;

			dGVTriparingredient.DataSource = bindingSourcePlatsTriesParIngredient;


		}
	}
}
