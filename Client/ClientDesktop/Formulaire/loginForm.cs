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

namespace ClientDesktop.Formulaire
{
	public partial class loginForm : Form
	{
		public string login = "";
		public string motdepasse = "";

		public loginForm()
		{
			InitializeComponent();
			btnLogin.Click += btnLogin_Click; ;
		}

		private async void btnLogin_Click(object sender, EventArgs e)
		{
			 login = txtBoxLogin.Text;
			 motdepasse = txtboxPassword.Text;

			 var result = await AuthentificationService.Getinstance().SignIn(login, motdepasse);

			 if (result)
			 {
				FenetreCommande fenCommande = new FenetreCommande();
				fenCommande.Show();
			}
			 else
			 {
				 MessageBox.Show("Veuillez entrer des identifiants valides");
			 }
		}


	}

}
