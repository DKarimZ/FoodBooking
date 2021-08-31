using BLLC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;

namespace ClientDesktop
{
	public partial class fenetreAjoutPlat : Form
	{

		private readonly IRestaurationService _restaurationService;

		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceIngredients = new BindingSource();
		private BindingSource bindingSourceIngredieentsinnewplat = new BindingSource();
		List<PlatIngredient> liste = new List<PlatIngredient>();


		public fenetreAjoutPlat()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			Loadplats();
			LoadIngredients();
			LoadTypePlats();
		
		}


		public async void Loadplats()
		{
			PageRequest pagerequest = new PageRequest(page: 1, 60);

			Task<PageResponse<Plat>> platsTask = _restaurationService.GetAllPlats(pagerequest);
			var plats = await platsTask;
			bindingSourcePlats.DataSource = plats.Data;


			platGridView.DataSource = bindingSourcePlats;

		}


		public async void LoadIngredients()
		{
		 List<PlatIngredient> platingredients = new();
		PageRequest pagerequest = new PageRequest(page: 1, 30);

			Task<PageResponse<Ingredient>> ingredientsTask = _restaurationService.GetAllIngredients(pagerequest);
			var ingredients = await ingredientsTask;
			bindingSourceIngredients.DataSource = ingredients.Data;


			IngredientGridView.DataSource = bindingSourceIngredients;


			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

			ingredient.NomIngredient = (IngredientGridView.Rows[IngredientGridView.CurrentRow.Index].Cells[1].Value).ToString();

			txtboxingredientaajouter.Text = ingredient.NomIngredient;


			

			var bindingList = new BindingList<PlatIngredient>(platingredients);
			var source = new BindingSource(bindingList, null);
			dgvIngredientsinnewplat.DataSource = source;

		}

		public async void LoadTypePlats()
		{


			Plat plat = new Plat();

			TypePlat typeplat = new TypePlat();
			typeplat.IdTypePlat = 2;
			plat.typePlat = typeplat;
			lbTypeplat.Items.Add("Entree");
			lbTypeplat.Items.Add("Plat");
			lbTypeplat.Items.Add("Dessert");
		}


			public Plat compute()
		{
			Plat plat = new Plat();
			List<PlatIngredient> liste = new List<PlatIngredient>();
			plat.Nom = txtBNomPlat.Text;
			plat.Score = 0;
			plat.PlatIngredient = CreateListIngredient();

			return plat;

		}

	



		public List<PlatIngredient> CreateListIngredient()
		{


			float quantite = Convert.ToSingle(tbquantiteingredientaajouter.Text);



			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

			
		
			liste.Add(new PlatIngredient(ingredient, quantite));
			return liste;


		}


		public Plat AjouterIngredient()
		{

			

			try
			{
				Plat plat = new Plat();

				float quantite = Convert.ToSingle(tbquantiteingredientaajouter.Text);



				List<PlatIngredient> platingredients = new();
				Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

				ingredient.NomIngredient = (IngredientGridView.Rows[IngredientGridView.CurrentRow.Index].Cells[1].Value).ToString();

				txtboxingredientaajouter.Text = ingredient.NomIngredient;
				
				
				bindingSourceIngredients.RemoveCurrent();

				
			//	plat.IdPlat = 32;
				plat.Nom = txtBNomPlat.Text;
				plat.Score = 0;
				//platingredients.Add(new PlatIngredient(ingredient as Ingredient, quantite));
				//plat.PlatIngredient = platingredients;

				CreateListIngredient();
				MessageBox.Show("L'ingrédient a bien été ajouté");
				return plat;
			}
			catch (Exception)
			{

				MessageBox.Show("une erreur a eu lieu lors de l'ajout de l'ingredient");
				return null;
			}


			


		}

		private async void btnAjouterplat_Click(object sender, EventArgs e)
		{
			try
			{



				await _restaurationService.CreatePlat(compute());
				MessageBox.Show("Votre nouveau plat a bien été ajouté");
			}
			catch (Exception)
			{

				MessageBox.Show("Votre nouveau plat n'a pas pu être ajouté");
			}
		}

		private void btnAjouteringredient_Click(object sender, EventArgs e)
		{

			AjouterIngredient();

			//CreateListIngredientAsync();


			dgvIngredientsinnewplat.Refresh();


		}

		private void IngredientGridView_SelectionChanged(object sender, EventArgs e)
		{
			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

			ingredient.NomIngredient = (IngredientGridView.Rows[IngredientGridView.CurrentRow.Index].Cells[1].Value).ToString();

			txtboxingredientaajouter.Text = ingredient.NomIngredient;

		

			
		}

		private async void btnSupprimer_Click(object sender, EventArgs e)
		{


			
			Plat platToRemove = bindingSourcePlats.Current as Plat;

			try
			{
				await _restaurationService.removePlat(platToRemove);
				MessageBox.Show("Ce plat a bien été supprimé");
			}
			catch (Exception exception)
			{

				MessageBox.Show("La suppression de ce plat n'a pas fonctionnée");
			}
		}
	}
	
}
