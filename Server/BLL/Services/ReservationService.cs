using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO;
using BO.Entity;
using DAL.UOW;
using DAL.Repository;
using BO.DTO.Requests;

namespace BLL.Services
{
	/// <summary>
	/// Permet de fournir les services de gestion des reservations
	/// </summary>
	internal class ReservationService : IReservationService
	{
		/// <summary>
		/// Permet d'utiliser l'interface Unit Of Work
		/// </summary>
		private readonly IUnitOfWork _db;

		public ReservationService(IUnitOfWork unitOfWork)
		{
			_db = unitOfWork;
		}


		// Methodes liées aux services de gestion des réservations

		#region Reservation

		public async Task<IEnumerable<Reservation>> GetAllReservations()
		{
			//Utilisation de la méthode GetAllAsync du repository IReservation
			IReservationRepository _reservations = _db.GetRepository<IReservationRepository>();
			IEnumerable<Reservation> reservations = await _reservations.GetAllAsync();

			return reservations.ToList();

		}




		public async Task<Reservation> GetReservationById(int IdReservation)
		{
			IReservationRepository _reservations = _db.GetRepository<IReservationRepository>();
			return await _reservations.GetAsync(IdReservation);
		}

		public async Task<Client> GetprofilByID(int IdClient)
		{
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			return await _clients.GetAsync(IdClient);
		}

		public async Task<Reservation> CreateReservation(ReservationsFilterRequest rfrs)
		{
			// l'utilisation de la methode InsertAsync se fait à l'interieur d'une transaction
			_db.BeginTransaction();
			IReservationRepository _reservations = _db.GetRepository<IReservationRepository>();
			Reservation rfr = await _reservations.InsertAsyncs(rfrs);
			_db.Commit();
			return rfr;


		}

		public async Task<Reservation> ModifyReservation(Reservation reservationToUpdate)
		{
			_db.BeginTransaction();
			IReservationRepository _reservations = _db.GetRepository<IReservationRepository>();
			try
			{
				//Ici on teste si la methode UpdateAsync a fonctionné (elle renvoie le boolean isModified)
				bool isModified = await _reservations.UpdateAsync(reservationToUpdate);
				_db.Commit();

				if (isModified)
				{
					//Si ça fonctionne on retourne la reservation modifiée
					return await Task.FromResult(reservationToUpdate);
				}
				else
				{
					//Sinon on retourne null
					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> removeReservation(int Idreservation)
		{
			// La méthode DeleteAsync se passe dans une transaction (eviter les problemes de clés primaires- etrangères,...)
			_db.BeginTransaction();
			IReservationRepository _reservations = _db.GetRepository<IReservationRepository>();
			bool isRemoved = await _reservations.DeleteAsync(Idreservation);
			_db.Commit();
			return isRemoved;

		}

		#endregion

		//Méthodes liés aux services de gestion clients

		#region Client

		public async Task<IEnumerable<Client>> GetAllClients()
		{
			//Utilisation de la méthode GetAllAsync du repository IClientRepository
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			IEnumerable<Client> clients = await _clients.GetAllAsync();

			return clients.ToList();

		}

		public async Task<Client> GetClientByIdAndPassword(string nom,string password)
		{
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			return await _clients.GetClientByUsernameAndPassword(nom,password);
		}
		

		public async Task<Client> GetClientById(int IdClient)
		{
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			return await _clients.GetAsync(IdClient);
		}

		public async Task<Client> CreateClient(Client newClient)
		{
			//La creation du nouveau client se passe dans une transaction
			_db.BeginTransaction();
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			Client nouvClient = await _clients.InsertAsync(newClient);
			_db.Commit();
			return nouvClient;


		}

		public async Task<bool> RemoveClientById(int IdClient)
		{
			// la méthode de suppression d'un client se passe dans une transaction
			_db.BeginTransaction();
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			bool isRemoved = await _clients.DeleteAsync(IdClient);
			_db.Commit();
			return isRemoved;

		}

		public async Task<Client> ModifyClient(Client clientToUpdate)
		{
			_db.BeginTransaction();
			IClientRepository _clients = _db.GetRepository<IClientRepository>();
			try
			{
				//Ici on teste si la methode UpdateAsync a fonctionné (elle renvoie le boolean isModified)

				bool isModified = await _clients.UpdateAsync(clientToUpdate);
				_db.Commit();

				if (isModified)
				{
					//Si ça fonctionne on retourne le client modifiée
					return await Task.FromResult(clientToUpdate);
				}
				else
				{
					//Sinon on retourne null
					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		#endregion

		//Méthodes liés aux services de gestion des commandes

		#region Commande

		public async Task<IEnumerable<Commande>> GetAllCommandes()
		{
			//Utilisation de la méthode GetAllAsync du repository ICommandeRepository

			ICommandeRepository _commandes = _db.GetRepository<ICommandeRepository>();
			IEnumerable<Commande> commandes = await _commandes.GetAllAsync();

			return commandes.ToList();

		}

		//public async Task<Commande> GetCommandeById(int IdCommande)
		//{
		//	ICommandeRepository _commandes = _db.GetRepository<ICommandeRepository>();
		//	return await _commandes.GetAsync(IdCommande);
		//}

		//public async Task<Commande> CreateCommande(Commande newCommande)
		//{
		//	//La methode InsertAsync est appelé dans une transaction
		//	_db.BeginTransaction();
		//	ICommandeRepository _commandes = _db.GetRepository<ICommandeRepository>();
		//	Commande nouvCommande = await _commandes.InsertAsync(newCommande);
		//	_db.Commit();
		//	return nouvCommande;


		//}

		public async Task<CommandDTO> GetCommande()
		{
			ICommandeRepository _commande = _db.GetRepository<ICommandeRepository>();
			CommandDTO commande = await _commande.GetAsync();

			return commande;

			#endregion
		}
	}
}
