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
	public class ClientRepository : IClientRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ReservationRepository> _logger;

		public ClientRepository(DbSession session, ILogger<ReservationRepository> logger)
		{
			_session = session;
			_logger = logger;
		}

		public async Task<IEnumerable<Client>> GetAllAsync()
		{
			var stmt = @"select * from client";
			return await _session.Connection.QueryAsync<Client>(stmt, null, _session.Transaction);
		}
		public async Task<Client> GetAsync(int id)
		{
			var stmt = @"select * from client where id = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Client>(stmt, new { Id = id }, _session.Transaction);
		}
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

		public Task<Client> GetClientByUsernameAndPassword(string nom, string password)
		{
			//TODO réécrire la requete avec un nom au lieu du Username
			var stmt = @"select * from client
						 Where Nom = @Nom AND Password = @Password";

			return  _session.Connection.QueryFirstOrDefaultAsync<Client>(stmt, new { Nom = nom, Password = password }, _session.Transaction);

		}
	}
}

