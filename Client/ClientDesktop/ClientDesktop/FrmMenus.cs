using BLLC.Services;
using BO.Entity;
using System;
using System.Collections;
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
	public partial class FrmMenus : Form
	{

		public bool isCreation = false;
		private readonly IRestaurationService _restaurationService;


		

		private BindingSource bindingSourceService = new BindingSource();
		private BindingSource bindingSourcePlats = new BindingSource();
		private BindingSource bindingSourceEntrees = new BindingSource();
		private BindingSource bindingSourceDesserts = new BindingSource();



		public FrmMenus()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();

			this.LoadMenus();
			this.LoadAlllistofPlats();
			}

		public void Initialize(Service menu)
		{
			if (menu != null)
			{
				//listentrees.Text = menu.Plats[0].ToString();
				//listplats.Text = menu.Plats[1].ToString();
				//textBox3.Text = menu.Plats[2].ToString();
			}

		}

		public Service Compute()
		{
			Service menu = new Service();

			List<Plat> plats = new List<Plat>(){ new Plat(),new Plat(),new Plat()};
			menu.dateJourservice = dateTimePicker1.Value;
			menu.Midi = true;
			menu.Plats = plats;
			menu.IdService = Convert.ToInt32(menuGridView.Rows[menuGridView.CurrentRow.Index].Cells[0].Value);



			plats[0].IdPlat =  Convert.ToInt32(entreegridview.Rows[entreegridview.CurrentRow.Index].Cells[0].Value);
			plats[1].IdPlat = Convert.ToInt32(platGridView.Rows[platGridView.CurrentRow.Index].Cells[0].Value);
			plats[2].IdPlat = Convert.ToInt32(dessertGridView.Rows[dessertGridView.CurrentRow.Index].Cells[0].Value);
			//plats[0].Nom = listentrees.GetItemText(listentrees.SelectedValue);

			//plats[1].Nom = listPlats.GetItemText(listPlats.SelectedValue);

			//plats[2].Nom = listDesserts.GetItemText(listDesserts.SelectedValue);

			return menu;


		}

		public async void LoadMenus()
		{
			Task<IEnumerable<Service>> menuTask = _restaurationService.GetAllServices();
			IEnumerable<Service> menu = await menuTask;
			bindingSourceService.DataSource = menu;

			menuGridView.DataSource = bindingSourceService;
			
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
			bindingSourceDesserts.DataSource = plats;

			listentrees.DataSource = entrees;
			listPlats.DataSource = plats;
			listDesserts.DataSource = desserts;

			listentrees.DisplayMember = "Nom";
			listPlats.DisplayMember = "Nom";
			listDesserts.DisplayMember = "Nom";

			entreegridview.DataSource = entrees;
			platGridView.DataSource = plats;
			dessertGridView.DataSource = desserts;


		}




		private async  void btnAdhMenu_Click(object sender, EventArgs e)
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

		private async void btnSuppMenu_Click(object sender, EventArgs e)
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
	}
		
	}

