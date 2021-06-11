using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using DAL.UOW;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	/// <summary>
	/// Permet l'acces aux données de la BDD
	/// </summary>
	public class ClientRepository : IClientRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ReservationRepository> _logger;

		public ClientRepository(DbSession session, ILogger<ReservationRepository> logger)
		{
			_session = session;
			_logger = logger;
		}



		/// <summary>
		/// Permet d'obtenir la liste des clients depuis la BDD (sans pagination)
		/// </summary>
		/// <returns>Retourne la liste des clients</returns>
		public async Task<IEnumerable<Client>> GetAllAsync()
		{
			var stmt = @"select * from client";
			return await _session.Connection.QueryAsync<Client>(stmt, null, _session.Transaction);
		}



		/// <summary>
		/// Permet d'obteninr un client en fonction de son identifiant depuis la BDD
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne </returns>
		public async Task<Client> GetAsync(int id)
		{
			var stmt = @"select * from client where id = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Client>(stmt, new { Id = id }, _session.Transaction);
		}



		/// <summary>
		/// Permet de mettre à jour un client depuis la BDD
		/// </summary>
		/// <param name="clientToUpdate">Le client à mettre à jour</param>
		/// <returns>Retourne le client mis à jour</returns>
		public async Task<bool> UpdateAsync(Client clientToUpdate)
		{
			var stmt = @"update client set nom = @nom, prenom = @prenom, telephone = @telephone from client where IdClient = @IdClient";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, clientToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}



		/// <summary>
		/// Permet d'ajouter un client dans la BDD
		/// </summary>
		/// <param name="clientToCreate">le client à ajouter</param>
		/// <returns>Retourne le cleint créé</returns>
		public async Task<Client> InsertAsync(Client clientToCreate)
		{
			var stmt = @"insert into client(nom, prenom, telephone) output INSERTED.ID values (@nom, @prenom, @telephone)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, clientToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}



		/// <summary>
		/// Permet de supprimer un client en BDD à partir de son identifiant
		/// </summary>
		/// <param name="idclient"></param>
		/// <returns>Retourne un booléan en fonction du succès de la suppression</returns>
		public async Task<bool> DeleteAsync(int idclient)
		{
			var stmt = @"delete from menu where IdClient = @IdClient";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { idClient = idclient }, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;

			}
		}



		/// <summary>
		/// Permet d'obtenir un pageResponse de tous les clients présent dans la base de données
		/// </summary>
		/// <param name="pageRequest">Prebd en paramètre un PageRequest avec numéro de page et Nombres de clients par page</param>
		/// <returns></returns>
		public async Task<PageResponse<Client>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from client
						ORDER BY IdClient
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNt(*) FROM client ";

			IEnumerable<Client> clientTask = await _session.Connection.QueryAsync<Client>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Client>(pageRequest.Page, pageRequest.PageSize, countTask, (clientTask).ToList());
		}



		/// <summary>
		/// Permet d'obtenir un client en fonction de son nom et de son mot de passse
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="password"></param>
		/// <returns>Retourne le client ciblé en fonction du nom et mot de passe</returns>
		public Task<Client> GetClientByUsernameAndPassword(string nom, string password)
		{
			//TODO réécrire la requete avec un nom au lieu du Username
			var stmt = @"select * from client
						 Where Nom = @Nom AND Password = @Password";

			return  _session.Connection.QueryFirstOrDefaultAsync<Client>(stmt, new { Nom = nom, Password = password }, _session.Transaction);

		}
	}
}

