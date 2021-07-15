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
		public fenPlats()
		{
			InitializeComponent();
			LoadPlats();
			LoadButtons();
		}

		public void LoadPlats()
		{
			pictureBox1.ImageLocation = "C://logo.jpg";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.ImageLocation = "C://banniereresto.png";
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		public void LoadButtons()
		{ 

			button1.Image = Image.FromFile("C://accueil.png");
			button2.Image = Image.FromFile("C://btnplat3.png");
			button3.Image = Image.FromFile("C://servicesss.png");
			button4.Image = Image.FromFile("C://commandes.png");
			button5.Image = Image.FromFile("C://reglages.png");
			button6.Image = Image.FromFile("C://accueil.png");
			button1.ImageAlign = ContentAlignment.MiddleCenter;
			button1.TextAlign = ContentAlignment.MiddleCenter;
		
			// Give the button a flat appearance.
			
		}

	}
}
