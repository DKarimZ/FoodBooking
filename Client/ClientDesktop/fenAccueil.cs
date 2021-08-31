using ClientDesktop.Formulaire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktop
{
	public partial class fenAccueil : Form
	{
		public fenAccueil()
		{
			InitializeComponent();
			LoadImages();
			

		}


		public void LoadImages()
		{

			pictureBox1.ImageLocation = "C://cooking.gif";
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			
		

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Hide();
			fenLogin fenLog = new fenLogin();
			fenLog.Show();
			
		}
	}
}
