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
	public partial class FrmMenus : Form
	{

		public bool isCreation = false;
		private readonly IRestaurationService _restaurationService;


		

		private BindingSource bindingSource = new BindingSource();

		public FrmMenus()
		{
			_restaurationService = new RestaurationService();
			InitializeComponent();

			this.LoadMenus();
		}

		public void Initialize(Service menu)
		{
			if (menu != null)
			{
				textBox1.Text = menu.Plats[0].ToString();
				textBox2.Text = menu.Plats[1].ToString();
				textBox3.Text = menu.Plats[2].ToString();
			}

		}

		public Service Compute()
		{
			Service menu = new Service();
			return new();






		}

		public async void LoadMenus()
		{
			Task<IEnumerable<Service>> menuTask = _restaurationService.GetAllServices();
			IEnumerable<Service> menu = await menuTask;
			bindingSource.DataSource = menu;

			menuGridView.DataSource = bindingSource;

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
	}
		
	}

