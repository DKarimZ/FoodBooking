using BLLC.Services;
using BO.DTO;
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


		private BindingSource bindingSourcePlatsTriesParType = new BindingSource();
		private BindingSource bindingSourcePlatsTriesParpopularite = new BindingSource();
		private BindingSource bindingSourcePlatsTriesParIngredient = new BindingSource();


		public fenPlats()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			LoadImages();
			Loadplats();
			LoadIngredients();
			LoadTypePlats();
			LoadListeTypePlat();


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

		public void LoadListeTypePlat(){
			listBox1.Items.Add("Entree");
			listBox1.Items.Add("Plat");
			listBox1.Items.Add("Dessert");

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
			dataGridView1.Columns["TypePlat"].Visible = true;
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

		public Plat compute2()
		{
			Plat plat = new Plat();
			List<PlatIngredient> liste = new List<PlatIngredient>();
			plat.Nom = textBox2.Text;
			plat.Score = 0;


			plat.PlatIngredient = CreateListIngredient();
			plat.IdPlat = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
			return plat;


		}

		public List<PlatIngredient> CreateListIngredient()
		{
			

			float quantite = Convert.ToSingle(textBox5.Text);



			Ingredient ingredient = bindingSourceIngredients.Current as Ingredient;

			PlatIngredient platIng = new PlatIngredient(ingredient, quantite);
			bool notFound = true;
			for (int i = 0; i < liste.Count ;i++){
				
				if(liste.ElementAt(i).Ingredient.Equals(ingredient)){

					liste.ElementAt(i).Quantite = quantite;
					notFound = false;
					break;
				}
			}

			if(notFound){
			liste.Add(new PlatIngredient(ingredient, quantite)); 
				}
			return liste;


		}

		public Plat AjouterIngredient()
		{
			textBox5.BackColor = System.Drawing.Color.White;
			float quantiteTotal = 0;
			float prixTotal = 0;


			try
			{
				Plat plat = new Plat();
				float quantite;
				if(!float.TryParse(textBox5.Text,out quantite)){
					MessageBox.Show("Veuillez entrer une quantité entière ou avec une virgule");
					textBox5.BackColor = System.Drawing.Color.Red;
					return null;
				}
				//float quantite = Convert.ToSingle(textBox5.Text);

				

				
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
				dataGridView3.CurrentRow.Selected = false;
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

			textBox2.BackColor = System.Drawing.Color.White;
			try
			{
				if(string.IsNullOrEmpty(textBox2.Text)){
					MessageBox.Show("Veuillez entrer le nom du plat");
					textBox2.BackColor = System.Drawing.Color.LightSalmon;
				
					textBox2.Select();

				}
				else if(listBox2.SelectedItem == null){

					MessageBox.Show("Veuillez renseigner le type de plat");
					listBox2.BackColor = System.Drawing.Color.LightSalmon;
					listBox2.Select();
				}
				else if(listView1.Items.Count==0){

					MessageBox.Show("Veuillez ajouter au moins un ingrédient à ce plat");
				}

				else{
				await _restaurationService.CreatePlat(compute());
				MessageBox.Show("Votre nouveau plat a bien été ajouté");
				}
					
			}
			catch (Exception)
			{

				MessageBox.Show("Votre nouveau plat n'a pas pu être ajouté");
					
			}
			
		}

		private async void button11_Click(object sender, EventArgs e)
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

		private async void button7_Click(object sender, EventArgs e)
		{
			Task<IEnumerable<Plat>> platstriesparpopulariteTask = _restaurationService.GetAllPlatsByPopularity();
			var platstriesparpopularite = await platstriesparpopulariteTask;

			bindingSourcePlatsTriesParpopularite.DataSource = platstriesparpopularite;

			dataGridView1.DataSource = bindingSourcePlatsTriesParpopularite;
		}

		private async void button8_Click(object sender, EventArgs e)
		{
			Task<IEnumerable<Plat>> platstriespartypeTask = _restaurationService.GetAllPlatsByType((listBox1.SelectedIndex)+1);
			var platstries = await platstriespartypeTask;
			bindingSourcePlatsTriesParType.DataSource = platstries;


			dataGridView1.DataSource = bindingSourcePlatsTriesParType;
			dataGridView1.Refresh();



		}

		private async void button9_Click(object sender, EventArgs e)
		{
			int IdIngredient = Convert.ToInt16(dataGridView3.CurrentRow.Cells[0].Value);

			Task<IEnumerable<Plat>> platstriespringredientTask = _restaurationService.GetAllPlatsByIngredient(IdIngredient);
			var platstriesparingredient = await platstriespringredientTask;

			bindingSourcePlatsTriesParIngredient.DataSource = platstriesparingredient;

			dataGridView1.DataSource = bindingSourcePlatsTriesParIngredient;
		}

		private async void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{

			

			int idPlat = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
			textBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
			listBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
			    //	DateTime date = Convert.ToDateTime(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[2].Value);
																															 //	bool midi = Convert.ToBoolean(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[1].Value);

			//	int rowIndex = 0;
			//	int rowIndexPlat = 0;
			//	int rowIndexdessert = 0;

			try
			{

				ListViewItem item1 = null;


				listView1.Items.Clear();
				

				Task<IngredientsofPlatDTO> ingredientsTask = _restaurationService.GetAllIngredientsByIdPlat(idPlat);
				IngredientsofPlatDTO ingPlat = await ingredientsTask;


				foreach(EntryIOPDTO ing in ingPlat.ingredients)
				{
			      item1 = new ListViewItem(new string[] { ing.NomIngredient, ing.Quantite.ToString(), ((ing.PrixMoyen) * ing.Quantite).ToString() });
					listView1.Items.Add(item1);
				}
				

				listView1.Refresh();
				//		IEnumerable<Plat> polos = await poloTask;
				//		Plat entree = polos.ToList()[0];
				//		Plat plat = polos.ToList()[1];
				//		Plat dessert = polos.ToList()[2];
				//		bindingSourceEntrees.DataSource = entree;
				//		bindingSourcePlats.DataSource = plat;
				//		bindingSourceDesserts.DataSource = dessert;





				//		string nom = entree.Nom;



				//		DataGridViewRow row = dataGridView1.Rows
				//			.Cast<DataGridViewRow>()
				//			.Where(r => r.Cells["Nom"].Value.ToString().Equals(nom))
				//			.First();

				//		rowIndex = row.Index;


				//		dataGridView1.Rows[rowIndex].Selected = true;





				//		string nomplat = plat.Nom;



				//		DataGridViewRow rowduPlat = dataGridView5.Rows
				//			.Cast<DataGridViewRow>()
				//			.Where(s => s.Cells["Nom"].Value.ToString().Equals(nomplat))
				//			.First();

				//		rowIndexPlat = rowduPlat.Index;

				//		dataGridView5.Rows[rowIndexPlat].Selected = true;



				//		string nomDessert = dessert.Nom;


				//		DataGridViewRow rowDessert = dataGridView4.Rows
				//			.Cast<DataGridViewRow>()
				//			.Where(t => t.Cells["Nom"].Value.ToString().Equals(nomDessert))
				//			.First();

				//		rowIndexdessert = rowDessert.Index;




				//		dataGridView4.Rows[rowIndexdessert].Selected = true;


				//		//Plat dish = dataGridView5.Rows[rowIndexPlat].DataBoundItem as Plat;
				//		//dish = plat;
				//		//Plat desert = dataGridView4.Rows[rowIndexdessert].DataBoundItem as Plat;
				//		//desert = dessert;

				//		dataGridView1.Refresh();
				//		dataGridView4.Refresh();
				//		dataGridView5.Refresh();
				//		//	dataGridView9.Refresh();
				//		//dataGridView5.Rows[dataGridView9.CurrentRow.Index].Cells[0].Value = plat.IdPlat;
				//		//dataGridView4.Rows[dataGridView9.CurrentRow.Index].Cells[0].Value = dessert.IdPlat;

				//		//	MessageBox.Show("ça fonctionne");


			}
			catch (Exception exception)
			{
				MessageBox.Show("ça ne fonctionne pas");
			}
		}

		private async void button10_Click(object sender, EventArgs e)
		{
		


			try
			{
				
				await _restaurationService.UpdatePlat(compute2());
				MessageBox.Show("le plat a bien été modifié");

			}

			catch (Exception exception)
			{
				MessageBox.Show("ça ne fonctionne pas");
			}   
		}
	}
	
}
