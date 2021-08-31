using BLLC.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktop
{
	public partial class fenPlats : Form
	{

		private readonly IRestaurationService _restaurationService;

		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceIngredients = new BindingSource();
		private BindingSource bindingSourceIngredieentsinnewplat = new BindingSource();
		List<PlatIngredient> liste = new List<PlatIngredient>();


		public fenPlats()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			LoadImages();
			Loadplats();
			LoadIngredients();
			LoadTypePlats();


		}

		public void LoadImages()
		{
			pictureBox1.ImageLocation = "C://logo.jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.ImageLocation = "C://banniereresto.png";
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		public async void Loadplats()
		{
			PageRequest pagerequest = new PageRequest(page: 1, 60);

			Task<PageResponse<Plat>> platsTask = _restaurationService.GetAllPlats(pagerequest);
			var plats = await platsTask;
			bindingSourcePlats.DataSource = plats.Data;


			dataGridView1.DataSource = bindingSourcePlats;

		}

		public async void LoadIngredients()
		{
			List<PlatIngredient> platingredients = new();
			PageRequest pagerequest = new PageRequest(page: 1, 30);

			Task<PageResponse<Ingredient>> ingredientsTask = _restaurationService.GetAllIngredients(pagerequest);
			var ingredients = await ingredientsTask;
			bindingSourceIngredients.DataSource = ingredients.Data;
			dataGridView3.DataSource = bindingSourceIngredients;


			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;
			ingredient.NomIngredient = (dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value).ToString();
			textBox4.Text = ingredient.NomIngredient;

			var bindingList = new BindingList<PlatIngredient>(platingredients);
			var source = new BindingSource(bindingList, null);
			//dataGridView2.DataSource = source;

			if(dataGridView1.Columns["IdPlat"] != null && dataGridView1.Columns["TypePlat"] != null && dataGridView3.Columns["IdIngredient"] != null)
			{
			dataGridView1.Columns["IdPlat"].Visible = false;
			dataGridView1.Columns["TypePlat"].Visible = false;
			dataGridView3.Columns["IdIngredient"].Visible = false;
			}
		}

		public async void LoadTypePlats()
		{


			Plat plat = new Plat();

			TypePlat typeplat = new TypePlat();
			typeplat.IdTypePlat = 2;
			plat.typePlat = typeplat;
			listBox2.Items.Add("Entree");
			listBox2.Items.Add("Plat");
			listBox2.Items.Add("Dessert");
		}

		public Plat compute()
		{
			Plat plat = new Plat();
			List<PlatIngredient> liste = new List<PlatIngredient>();
			plat.Nom = textBox2.Text;
			plat.Score = 0;
			plat.PlatIngredient = CreateListIngredient();

			return plat;

		}

		public List<PlatIngredient> CreateListIngredient()
		{


			float quantite = Convert.ToSingle(textBox5.Text);



			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;



			liste.Add(new PlatIngredient(ingredient, quantite));
			return liste;


		}

		public Plat AjouterIngredient()
		{
			float quantiteTotal = 0;
			float prixTotal = 0;


			try
			{
				Plat plat = new Plat();
				float quantite = Convert.ToSingle(textBox5.Text);

				List<PlatIngredient> platingredients = new();
				Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

				ingredient.NomIngredient = (dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value).ToString();
				textBox4.Text = ingredient.NomIngredient;

				bindingSourceIngredients.RemoveCurrent();


	;
				//string[] row1 = { ingredient.NomIngredient, quantite.ToString(),((ingredient.PrixMoyen)*quantite).ToString() };
				
				ListViewItem item1 = new ListViewItem(new string[]{ ingredient.NomIngredient, quantite.ToString(), ((ingredient.PrixMoyen) * quantite).ToString() });

				listView1.Items.Add(item1);
			
				//listView1.Items.Add.(ingredient.NomIngredient, Convert.ToInt32(quantite));

				//	plat.IdPlat = 32;
				plat.Nom = textBox4.Text;
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





		private void button1_Click(object sender, EventArgs e)
		{
			Hide();
			fenPlats fen = new fenPlats();
			fen.Show();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Hide();
			fenService fen = new fenService();
			fen.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Hide();
			FenetreCommande fen = new FenetreCommande();
			fen.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Hide();
			fenetreTriPlat fen = new fenetreTriPlat();
			fen.Show();
		}

		private void dataGridView3_SelectionChanged(object sender, EventArgs e)
		{
			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

			ingredient.NomIngredient = (dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value).ToString();

			textBox4.Text = ingredient.NomIngredient;


		}

		private void button5_Click(object sender, EventArgs e)
		{
			AjouterIngredient();

			//CreateListIngredientAsync();


		//	dataGridView2.Refresh();
		}

		private async void button6_Click(object sender, EventArgs e)
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
	}
}
