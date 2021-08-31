using BLLC.Services;
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
	public partial class fenLogin : Form
	{

		private string login;
		private string motdepasse;


		public fenLogin()
		{
			InitializeComponent();
		}

		private async void ConnectBtn_Click(object sender, EventArgs e)
		{
			login = LoginTb.Text;
			motdepasse = MotPasseTb.Text;

			var result = await AuthentificationService.Getinstance().SignIn(login, motdepasse);

			if (result)
			{
				Hide();
				fenMenu fenMenu = new fenMenu();
				fenMenu.Show();
			}
			else
			{
				MessageBox.Show("Veuillez entrer des identifiants valides");
			}

		}
	}
}
