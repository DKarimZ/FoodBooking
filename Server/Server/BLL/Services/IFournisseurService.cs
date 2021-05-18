using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Entity;

namespace BLL.Services
{
	/// <summary>
	/// Interface du service Fournisseur - commande
	/// </summary>
	public interface IFournisseurService
	{
		//Services liés aux commandes
		#region Commande
		/// <summary>
		/// permet de créer une commande de façon asynchrone
		/// </summary>
		/// <param name="newCommande"></param>
		/// <returns>retourne une nouvelle commande</returns>
		Task<Commande> CreateCommande(Commande commande);

		#endregion
	}
}
