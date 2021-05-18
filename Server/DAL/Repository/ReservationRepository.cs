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
	public class ReservationRepository : IReservationRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ReservationRepository> _logger;

		public ReservationRepository(DbSession session, ILogger<ReservationRepository> logger)
		{
			_session = session;
			_logger = logger;
		}

		public async Task<IEnumerable<Reservation>> GetAllAsync()
		{
			var stmt = @"select * from reservation";
			return await _session.Connection.QueryAsync<Reservation>(stmt, null, _session.Transaction);
		}
		public async Task<Reservation> GetAsync(int id)
		{
			var stmt = @"select * from reservation where id = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Reservation>(stmt, new { Id = id }, _session.Transaction);
		}
		public async Task<bool> UpdateAsync(Reservation reservationToUpdate)
		{
			var stmt = @"update reservation set dateReservation = @dateReservation, repass = @repass from reservation join repas where IdReservation = @IdReservation";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, reservationToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}
		public async Task<Reservation> InsertAsync(Reservation reservationToCreate)
		{
			var stmt = @"insert into reservation(dateReservation, repass) output INSERTED.ID values (@dateReservation, @repass)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, reservationToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}
		public async Task<bool> DeleteAsync(int idReservation)
		{
			var stmt = @"delete from reservation where IdReservation = @IdReservation";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { idReservation = idReservation }, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;

			}
		}

		public async Task<PageResponse<Reservation>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from reservation
						ORDER BY IdReservation
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNt(*) FROM reservation ";

			IEnumerable<Reservation> reservationTask = await _session.Connection.QueryAsync<Reservation>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Reservation>(pageRequest.Page, pageRequest.PageSize, countTask, (reservationTask).ToList());
		}
	}
}
