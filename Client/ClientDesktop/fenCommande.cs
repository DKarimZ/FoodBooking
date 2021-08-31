using BLLC.Services;
using BO.DTO;
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
	public partial class fenCommande : Form
	{

		private readonly IFournisseurService _fournisseurService;

		private BindingSource bindingSourceCommande = new BindingSource();
		private BindingSource bindingSourceCommandePrice = new BindingSource();

		public fenCommande()
		{
			_fournisseurService = new FournisseurService();
			InitializeComponent();
			LoadImages();
			LoadCommande();
		}

		public void LoadImages()
		{
			pictureBox1.ImageLocation = "C://logo.jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.ImageLocation = "C://banniereresto.png";
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		public async void LoadCommande()
		{
			Task<CommandDTO> commandeTask = _fournisseurService.GetCommande();
			CommandDTO commande = await commandeTask;

			if(commande != null){
			bindingSourceCommande.DataSource = commande.Entries;
			txtBoxTotPrice.Text = commande.TotalPrice.ToString();

			dgvCommande.DataSource = bindingSourceCommande; }

			else{

				MessageBox.Show("Il n'y a aucune commande à visusaliser");

			}

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

	}
}
