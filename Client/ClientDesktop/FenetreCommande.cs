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
using BO.DTO;
using BO.Entity;

namespace ClientDesktop
{
	public partial class FenetreCommande : Form
	{

		private readonly IFournisseurService _fournisseurService;




		private BindingSource bindingSourceCommande = new BindingSource();
		private BindingSource bindingSourceCommandePrice = new BindingSource();


		public FenetreCommande()
		{
			_fournisseurService = new FournisseurService();
			InitializeComponent();
			LoadCommande();
		}


		public async void LoadCommande()
		{
			Task<CommandDTO> commandeTask = _fournisseurService.GetCommande();
			CommandDTO commande = await commandeTask;
			bindingSourceCommande.DataSource = commande.Entries;
			txtBoxTotPrice.Text= commande.TotalPrice.ToString();


			dgvCommande.DataSource = bindingSourceCommande;

		}


		private async void btnAfficher_Click(object sender, EventArgs e)
		{
			try
			{



				await _fournisseurService.GetCommande();
				MessageBox.Show("Voici la commande");
			}
			catch (Exception)
			{

				MessageBox.Show("Votre commande ne peut etre visualisée");
			}
		}

		
	}
}
