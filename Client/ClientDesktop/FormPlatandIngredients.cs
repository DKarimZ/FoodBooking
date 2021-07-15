using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLC.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;

namespace ClientDesktop
{
	public partial class FormPlatandIngredients : Form
	{
		private readonly IRestaurationService _restaurationService;

		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceIngredients = new BindingSource();

		
		

		public FormPlatandIngredients()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			Loadplats();
			LoadIngredients();
		}

		public async void Loadplats()
		{
			PageRequest pagerequest = new PageRequest(page: 1, 30);

			Task<PageResponse<Plat>> platsTask =  _restaurationService.GetAllPlats(pagerequest);
			var plats = await platsTask;
			bindingSourcePlats.DataSource = plats.Data;


			PlatsGridView.DataSource = bindingSourcePlats;

		}


		public async void LoadIngredients()
		{

			PageRequest pagerequest = new PageRequest(page: 1, 30);

			Task<PageResponse<Ingredient>> ingredientsTask = _restaurationService.GetAllIngredients(pagerequest);
			var ingredients = await ingredientsTask;
			bindingSourceIngredients.DataSource = ingredients.Data;


			ingredientsGridView.DataSource = bindingSourceIngredients;

		}

		public  Plat Compute()
		{
			Plat plat = new Plat();

			List<PlatIngredient> platingredients = new List<PlatIngredient>() {  };
			plat.IdPlat = 55;
			plat.Nom = txtbNom.Text;
			plat.Score = 0;
			//plat.typePlat = lbTypePlat;  binder le type de plat avec la liste
			plat.PlatIngredient = platingredients;
			float quantite = Convert.ToSingle(txtbquantite.Text);

			
			

			//menu.IdService = Convert.ToInt32(menuGridView.Rows[menuGridView.CurrentRow.Index].Cells[0].Value);

			//platingredients.Add(new PlatIngredient(ingredient, quantite));

			//plats[0].IdPlat = Convert.ToInt32(entreegridview.Rows[entreegridview.CurrentRow.Index].Cells[0].Value);
			//plats[1].IdPlat = Convert.ToInt32(platGridView.Rows[platGridView.CurrentRow.Index].Cells[0].Value);
			//plats[2].IdPlat = Convert.ToInt32(dessertGridView.Rows[dessertGridView.CurrentRow.Index].Cells[0].Value);


			return plat;


		}



		private async void btnAjouter_Click(object sender, EventArgs e)
		{
			try
			{



				await _restaurationService.CreatePlat(Compute());
				MessageBox.Show("Votre nouveau plat a bien été ajouté");
			}
			catch (Exception)
			{

				MessageBox.Show("Votre nouveau plat n'a pas pu être ajouté");
			}
		}
	}
}
