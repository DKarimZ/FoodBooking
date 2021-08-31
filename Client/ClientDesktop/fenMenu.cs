using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktop
{
	public partial class fenMenu : Form
	{
		public fenMenu()
		{
			InitializeComponent();
			LoadImages();
		}


		public void LoadImages()
		{
			



			pictureBox1.ImageLocation = "C://logo.Jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		

			pbPlats.ImageLocation = "C://platss.gif";
			pbPlats.SizeMode = PictureBoxSizeMode.StretchImage;
			pbMenus.ImageLocation = "C://menuss.gif";
			pbMenus.SizeMode = PictureBoxSizeMode.StretchImage;
		
			pbCommandes.ImageLocation = "C://commandes.gif";
			pbCommandes.SizeMode = PictureBoxSizeMode.StretchImage;
	
			pictureBox5.ImageLocation = "C://Reglages.gif";
			pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
		

			tableLayoutPanel1.BackgroundImage = Image.FromFile("C://fond.jpg");
			



		}

		private void pbPlats_Click(object sender, EventArgs e)
		{
			Hide();
			fenPlats fen = new fenPlats();
			fen.Show();
		}

		private void pbMenus_Click(object sender, EventArgs e)
		{
			Hide();
			fenService fen = new fenService();
			fen.Show();
		}

		

		private void pbCommandes_Click(object sender, EventArgs e)
		{
			Hide();
			fenCommande fen = new fenCommande();
			fen.Show();
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{

		}
	}


}



