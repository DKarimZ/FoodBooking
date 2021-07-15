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
	}
}
