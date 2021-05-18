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

		public void Initialize(Menu menu)
		{
			if (menu != null)
			{
				textBox1.Text = menu.Plats[0].ToString();
				textBox2.Text = menu.Plats[1].ToString();
				textBox3.Text = menu.Plats[2].ToString();
			}

		}

		public Menu Compute()
		{
			Menu menu = new Menu();
			menu.Plats = new List<Plat>();
			menu.Plats[0].nomPlat = textBox1.Text;
			menu.Plats[1].nomPlat = textBox2.Text;
			menu.Plats[2].nomPlat = textBox2.Text;


			return new Menu()
			{
				IdMenu = 7,
				Plats = menu.Plats

			};



			}

		public async void LoadMenus()
		{
			Task<IEnumerable<Menu>> menuTask = _restaurationService.GetAllMenus();
			IEnumerable<Menu> menu = await menuTask;
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

