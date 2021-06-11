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
	/// Permet l'accès aux données des commandes de la BDD
	/// </summary>
	public class CommandeRepository : ICommandeRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<CommandeRepository> _logger;

		public CommandeRepository(DbSession session, ILogger<CommandeRepository> logger)
		{
			_session = session;
			_logger = logger;
		}


		/// <summary>
		/// Permet d'ajouter une commande en BDD
		/// </summary>
		/// <param name="commandeToCreate"></param>
		/// <returns>Retourne la commande ajoutée</returns>
		public async Task<Commande> InsertAsync(Commande commandeToCreate)
		{
			var stmt = @"insert into commande(jourCommande, Ingredients) output INSERTED.ID values (@jourCommande, @Ingredients)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, commandeToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}



		/// <summary>
		/// Permet d'obtenir un PageResponse de toutes les commandes présentes en BDD
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Retourne un PageResponse de commande</returns>
		public async Task<PageResponse<Commande>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from commande
						ORDER BY IdCommande
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNt(*) FROM commande ";

			IEnumerable<Commande> commandeTask = await _session.Connection.QueryAsync<Commande>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Commande>(pageRequest.Page, pageRequest.PageSize, countTask, (commandeTask).ToList());
		}



		/// <summary>
		/// Permet d'obtenir une commande den fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retoune la commande identifiée</returns>
		public async Task<Commande> GetAsync(int id)
		{
			var stmt = @"select * from commande where id = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Commande>(stmt, new { Id = id }, _session.Transaction);
		}



		/// <summary>
		/// Permet d'obtenir la liste des commandes présentes en BDD
		/// </summary>
		/// <returns>Retourne la lliste des commandes</returns>
		public async Task<IEnumerable<Commande>> GetAllAsync()
		{
			var stmt = @"select * from commande";
			return await _session.Connection.QueryAsync<Commande>(stmt, null, _session.Transaction);
		}
	}
}
