using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO;
using BO.DTO.Requests;

namespace BLL.Services
{
	/// <summary>
	/// Interface des services liées aux réservations : reservation - client - commande
	/// </summary>
	public interface IReservationService
	{
		//Service liés aux réservations
		#region Reservation
		/// <summary>
		/// Permet de récupérer la liste des réservations
		/// </summary>
		/// <returns>retourne la liste des réservations</returns>
		Task<IEnumerable<Reservation>> GetAllReservations();

		/// <summary>
		/// permet de récupérer une réservation en fonction de son Identifiant
		/// </summary>
		/// <param name="IdReservation"></param>
		/// <returns>retourne uen réservation en particulier</returns>
		Task<Reservation> GetReservationById(int IdReservation);

		/// <summary>
		/// Permet de créer une nouvelle réservation 
		/// </summary>
		/// <param name="newReservation"></param>
		/// <returns>retourne la nouvelle réservation</returns>
		Task<Reservation> CreateReservation(ReservationsFilterRequest rfr);

		/// <summary>
		/// Permet de modifier une réservation
		/// </summary>
		/// <param name="reservationToUpdate"></param>
		/// <returns>retourne la réservation modifiée</returns>
		Task<Reservation> ModifyReservation(Reservation reservationToUpdate);

		/// <summary>
		/// Permet de supprimer une réservation
		/// </summary>
		/// <param name="Idreservation"></param>
		/// <returns>retourne un booléen en fonction du résultat</returns>
		Task<bool> removeReservation(int Idreservation);

		#endregion
		//Services liés aux clients
		#region Client
		/// <summary>
		/// Permet de récupérer la liste des clients
		/// </summary>
		/// <returns>retourne la liste des clients</returns>
		Task<IEnumerable<Client>> GetAllClients();

		/// <summary>
		/// Permet de récupérer un client en fonction de son Identifiant
		/// </summary>
		/// <param name="IdClient"></param>
		/// <returns>retourne un client en particulier</returns>
		Task<Client> GetClientById(int IdClient);


		Task<Client> GetprofilByID(int IdClient);
		/// <summary>
		/// Permet de créer un nouveau client
		/// </summary>
		/// <param name="newclient"></param>
		/// <returns>retourne le nouveau client</returns>
		Task<Client> CreateClient(Client newclient);

		/// <summary>
		/// Permet de modifier un client
		/// </summary>
		/// <param name="clientToUpdate"></param>
		/// <returns>retourne le client modifié</returns>
		Task<Client> ModifyClient(Client clientToUpdate);

		/// <summary>
		/// Permet de supprimer un client à partir de son Indetifiant
		/// </summary>
		/// <param name="IdClient"></param>
		/// <returns>retourne un boolean en fonction de la réussite de la suppression</returns>
		Task<bool> RemoveClientById(int IdClient);

		Task<Client> GetClientByIdAndPassword(string nom, string password);

		#endregion
		//Services liés aux commandes
		#region Commande
		/// <summary>
		/// Permet de récupérer la liste des commandes
		/// </summary>
		/// <returns>retourne la liste des commandes</returns>
		Task<IEnumerable<Commande>> GetAllCommandes();

		/// <summary>
		/// permet de récupérer une commande à partir de son Identifiant
		/// </summary>
		/// <param name="IdCommande"></param>
		/// <returns>retourne une commande en particulier</returns>
		Task<CommandDTO> GetCommande();

		/// <summary>
		/// Permet de créer une nouvelle commande
		/// </summary>
		/// <param name="newCommande"></param>
		/// <returns>retourne la nouvelle commande</returns>
		
		#endregion
	}
}
