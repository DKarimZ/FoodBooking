using BO.Entity;
using DAL.UOW;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO;

namespace BLL.Services
{
	/// <summary>
	/// Permet de Fournir les services du fournisseur
	/// </summary>
	internal class FournisseurService : IFournisseurService
	{
		/// <summary>
		/// permet d'utiliser l'Interface Unit Of Work
		/// </summary>
		private readonly IUnitOfWork _db;

		//Constructeur du service Fournisseur
		public FournisseurService(IUnitOfWork db)
		{
			_db = db;

		}

		//méthodes liés aux services de gestion des commandes
		#region Commmande
	
		/// <summary>
		/// Permet de récupérer les commandes
		/// </summary>
		/// <returns>Retourne un DTO(CommandDTO°</returns>
		public async Task<CommandDTO> GetCommande( )
		{
			_db.BeginTransaction();
			//Récupération de l'Interface du repository Commande (ICommandeRepository)
			ICommandeRepository _commandes = _db.GetRepository<ICommandeRepository>();
			//Utilisation de sa méthode Insert
			CommandDTO Commande = await _commandes.GetAsync();
			//Fin transaction
			_db.Commit();
			//retour de la nouvelle commande 
			return Commande;
		}


		#endregion

	}

}



