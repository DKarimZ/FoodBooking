using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entity
{
	/// <summary>
	/// représente un objet client
	/// </summary>
	public class Client
	{
		/// <summary>
		/// identifiant du client
		/// </summary>
		public int? IdClient { get; set; }

		/// <summary>
		/// nom du Client
		/// </summary>
		public string nom { get; set; }

		/// <summary>
		/// prenom du client
		/// </summary>
		public string prenom { get; set; }

		/// <summary>
		/// Numéro de telephone du client
		/// </summary>
		public string telephone { get; set; }

		/// <summary>
		/// Constructeur par defaut pour la serialisation de l'API
		/// </summary>

		public string role { get; set; }

		//Creer le login et le password

		public Client()
		{

		}

		/// <summary>
		/// Constructeur utilitaire avec toutes les propriétés
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nom"></param>
		/// <param name="prenom"></param>
		/// <param name="telephone"></param>
		public Client(int? id, string nom, string prenom, string telephone)
		{
				IdClient = id;
				this.nom = nom;
				this.prenom = prenom;
				this.telephone = telephone;
		}

		// Methode Equals (Si besoin de la redéfinir)
		public override bool Equals(object obj)
		{
			return obj is Client client &&
				   IdClient == client.IdClient &&
				   nom == client.nom &&
				   prenom == client.prenom &&
				   telephone == client.telephone;
		}

		public override int GetHashCode()
		{
			int hashCode = 1551227788;
			hashCode = hashCode * -1521134295 + IdClient.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(prenom);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telephone);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(role);
			return hashCode;
		}

		// Methode GetHashCode (si besoin de la redéfinir)


	}
}
