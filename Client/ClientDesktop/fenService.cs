using BLLC.Services;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktop
{
	public partial class fenService : Form
	{

		public bool isCreation = false;
		private readonly IRestaurationService _restaurationService;

		private BindingSource bindingSourceService = new BindingSource();
		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceEntrees = new BindingSource();
		private BindingSource bindingSourceDesserts = new BindingSource();


		public fenService()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			this.LoadPlats();
			this.LoadMenus();
			this.LoadAlllistofPlats();
		}

		public Service Compute()
		{
			Service menu = new Service();

			List<Plat> plats = new List<Plat>() { new Plat(), new Plat(), new Plat() };
			menu.dateJourservice = dateTimePicker1.Value;
			menu.Midi = midiCB.Checked;
			menu.Plats = plats;
			//menu.IdService = Convert.ToInt32(menuGridView.Rows[menuGridView.CurrentRow.Index].Cells[0].Value);



			plats[0].IdPlat = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
			plats[1].IdPlat = Convert.ToInt32(dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[0].Value);
			plats[2].IdPlat = Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value);


			return menu;


		}

		public async void LoadMenus()
		{
			Task<IEnumerable<Service>> menuTask = _restaurationService.GetAllServices();
			IEnumerable<Service> menu = await menuTask;
			bindingSourceService.DataSource = menu;
			var date = DateTime.Now;
			var nextSunday = date.AddDays(7 - (int)date.DayOfWeek);
			dateTimePicker1.MinDate = nextSunday.AddDays(1);
			dateTimePicker1.MaxDate = nextSunday.AddDays(7);

		//	menuGridView.DataSource = bindingSourceService;

		}

		public async void LoadAlllistofPlats()
		{
			Task<IEnumerable<Plat>> entreeTask = _restaurationService.GetAllPlatsByType(1);
			IEnumerable<Plat> entrees = await entreeTask;
			bindingSourceEntrees.DataSource = entrees;

			Task<IEnumerable<Plat>> platTask = _restaurationService.GetAllPlatsByType(2);
			IEnumerable<Plat> plats = await platTask;
			bindingSourcePlats.DataSource = plats;

			Task<IEnumerable<Plat>> dessertTask = _restaurationService.GetAllPlatsByType(3);
			IEnumerable<Plat> desserts = await dessertTask;
			bindingSourceDesserts.DataSource = desserts;

			List<Plat> entreesList = entrees.ToList();
			List<Plat> platList = plats.ToList();
			List<Plat> dessertList = desserts.ToList();


			textBox1.DataBindings.Add("Text", entrees, "Nom");
			textBox2.DataBindings.Add("Text", plats, "Nom");
			textBox3.DataBindings.Add("Text", desserts, "Nom");
			//textBox2.Text = platList[0].Nom;
			//textBox3.Text = dessertList[0].Nom;




			dataGridView1.DataSource = entrees;
			dataGridView5.DataSource = plats;
			dataGridView4.DataSource = desserts;

			dataGridView1.Columns["IdPlat"].Visible = false;
			dataGridView5.Columns["IdPlat"].Visible = false;
			dataGridView4.Columns["IdPlat"].Visible = false;

			dataGridView1.Columns["TypePlat"].Visible = false;
			dataGridView5.Columns["TypePlat"].Visible = false;
			dataGridView4.Columns["TypePlat"].Visible = false;

		}



		public void LoadPlats()
		{
			pictureBox1.ImageLocation = "C://logo.jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.ImageLocation = "C://banniereresto.png";
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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

		

		private async void btnAjouterPlat_Click(object sender, EventArgs e)
		{
			try
			{



				await _restaurationService.CreateMenu(Compute());
				MessageBox.Show("Votre menu a bien été ajouté");
			}
			catch (Exception)
			{

				MessageBox.Show("Votre menu n'a pas pu être ajouté");
			}
		}

		private async void btnModifierPlat_Click(object sender, EventArgs e)
		{
			try
			{
				await _restaurationService.RemoveMenu(Compute());
				MessageBox.Show("ce service a bien été supprimé");
				;
			}
			catch (Exception exception)
			{
				MessageBox.Show("Ce menu n'a pas pu être supprimé");
			}
		}


		private async void btnSupprimerPlat_Click(object sender, EventArgs e)
		{
			try
			{
				await _restaurationService.UpdateMenu(Compute());
				MessageBox.Show("ce service a bien été modifié");
				;
			}
			catch (Exception exception)
			{
				MessageBox.Show("Ce menu n'a pas pu être modifié");
			}
		}
	}
}
