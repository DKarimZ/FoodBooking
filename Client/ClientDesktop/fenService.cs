﻿using BLLC.Services;
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

		/// <summary>
		/// Creation des binding sources pour bindage des dataGridViews
		/// </summary>
		private BindingSource bindingSourceService = new BindingSource();
		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceEntrees = new BindingSource();
		private BindingSource bindingSourceDesserts = new BindingSource();


		/// <summary>
		/// Constructeur de la méthode permettant de lancec les doifférentes méthodes lors de l'initialisation de la WinForm
		/// </summary>
		public fenService()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();
			this.LoadPlats();
			this.LoadMenus();
			this.LoadAlllistofPlats();
		}

		/// <summary>
		/// Méthode permettant de créer un service ) partir d'une liste de plats
		/// </summary>
		/// <returns></returns>
		public Service Compute()
		{
			Service menu = new Service();

			List<Plat> plats = new List<Plat>() { new Plat(), new Plat(), new Plat() };
			menu.dateJourservice = dateTimePicker1.Value;
			menu.Midi = midiCB.Checked;
			menu.Plats = plats;
			menu.IdService = Convert.ToInt32(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[0].Value);
			plats[0].IdPlat = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
			plats[1].IdPlat = Convert.ToInt32(dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[0].Value);
			plats[2].IdPlat = Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value);

			return menu;


		}


		/// <summary>
		/// Méthode permettanyt le chargement et l'affichage des Service dans le Datagridview
		/// </summary>
		public async void LoadMenus()
		{
			Task<IEnumerable<Service>> menuTask = _restaurationService.GetAllServices();
			IEnumerable<Service> menu = await menuTask;
			bindingSourceService.DataSource = menu;
			var date = DateTime.Now;
			var nextSunday = date.AddDays(7 - (int)date.DayOfWeek);
			dateTimePicker1.MinDate = nextSunday.AddDays(1);
			dateTimePicker1.MaxDate = nextSunday.AddDays(7);
			dataGridView9.DataSource = bindingSourceService;
			dataGridView9.Columns["idService"].Visible = false;
			dataGridView9.RowHeadersVisible = false;
		}


		/// <summary>
		/// Méthode permettant le chargement des plats dans les dtagtridViews 
		/// </summary>
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
			
			dataGridView1.DataSource = entrees;
			dataGridView5.DataSource = plats;
			dataGridView4.DataSource = desserts;

			dataGridView1.Columns["TypePlat"].Visible = false;
			dataGridView5.Columns["TypePlat"].Visible = false;
			dataGridView4.Columns["TypePlat"].Visible = false;

		}


		/// <summary>
		/// Méthode permettant de charger les éléments graphiques de la WinForm
		/// </summary>
		public void LoadPlats()
		{
			pictureBox1.ImageLocation = "C://logo.jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.ImageLocation = "C://banniereresto.png";
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		}



		//___________________________________________________________________________________________________________________//
		// Méthodes liés aux événements de clic sur les différent boutons de gauche pour naviguer sur une fenetre différente
		//___________________________________________________________________________________________________________________//
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
			fenCommande fen = new fenCommande();
			fen.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			
		}

		
		/// <summary>
		/// Méthode permettant de créer un Service
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnAjouterPlat_Click(object sender, EventArgs e)
		{
			try
			{
				if(await _restaurationService.CreateMenu(Compute()) != null)
				MessageBox.Show("Votre menu a bien été ajouté");

				else{

					MessageBox.Show("Il existe déjà un service au même moment");
				}
			}
			catch (Exception exception )
			{
				MessageBox.Show("Votre menu n'a pas pu être ajouté");
			}
		}

		/// <summary>
		/// Méthode permettant de supprmier un service en base de données
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnModifierPlat_Click(object sender, EventArgs e)
		{
			try
			{
				
				await _restaurationService.RemoveMenu(Compute());
				MessageBox.Show("ce service a bien été supprimé");
				dataGridView1.Refresh();
				dataGridView4.Refresh();
				dataGridView5.Refresh();
				dataGridView9.Refresh();
				
			}
			catch (Exception exception)
			{
				MessageBox.Show("Ce menu n'a pas pu être supprimé");
			}
		}

		/// <summary>
		/// Méthode permettant de mettre à jour un menu en base de données
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnSupprimerPlat_Click(object sender, EventArgs e)
		{
			try
			{
				
				await _restaurationService.UpdateMenu(Compute());
				MessageBox.Show("ce service a bien été modifié");
				dataGridView1.Refresh();
				dataGridView4.Refresh();
				dataGridView5.Refresh();
				dataGridView9.Refresh();
				;
			}
			catch (Exception exception)
			{
				MessageBox.Show("Ce menu n'a pas pu être modifié");
			}
		}


		/// <summary>
		/// Evenement lancé au click sur le datagridview et permettant d'affciher les plats correspondants à un service (click sur le service corrrespondant)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

			DateTime date = Convert.ToDateTime(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[2].Value);
			bool midi = Convert.ToBoolean(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[1].Value);

			int rowIndex = 0;
			int rowIndexPlat = 0;
			int rowIndexdessert = 0;

			try
			{

				dataGridView1.ClearSelection();
				dataGridView4.ClearSelection();
				dataGridView5.ClearSelection();

				Task<IEnumerable<Plat>> poloTask = _restaurationService.GetAllPlatsByDateServiceandMidi(date, midi);
				IEnumerable<Plat> polos = await poloTask;
				Plat entree = polos.ToList()[0];
				Plat plat = polos.ToList()[1];
				Plat dessert = polos.ToList()[2];
				bindingSourceEntrees.DataSource = entree;
				bindingSourcePlats.DataSource = plat;
				bindingSourceDesserts.DataSource = dessert;

				string nom = entree.Nom;
				DataGridViewRow row = dataGridView1.Rows
					.Cast<DataGridViewRow>()
					.Where(r => r.Cells["Nom"].Value.ToString().Equals(nom))
					.First();
				rowIndex = row.Index;
				dataGridView1.Rows[rowIndex].Selected = true;

				string nomplat = plat.Nom;
				DataGridViewRow rowduPlat = dataGridView5.Rows
					.Cast<DataGridViewRow>()
					.Where(s => s.Cells["Nom"].Value.ToString().Equals(nomplat))
					.First();
				rowIndexPlat = rowduPlat.Index;
				dataGridView5.Rows[rowIndexPlat].Selected = true;

				string nomDessert = dessert.Nom;
				DataGridViewRow rowDessert = dataGridView4.Rows
					.Cast<DataGridViewRow>()
					.Where(t => t.Cells["Nom"].Value.ToString().Equals(nomDessert))
					.First();
				rowIndexdessert = rowDessert.Index;
				dataGridView4.Rows[rowIndexdessert].Selected = true;

				dataGridView1.Refresh();
				dataGridView4.Refresh();
				dataGridView5.Refresh();
				
			}
			catch (Exception exception)
			{
				MessageBox.Show("ça ne fonctionne pas");
			}
		}
	}
}
