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


		/// <summary>
		/// Permet d'obtenir la liste de toutes les réservations présentes en BDD
		/// </summary>
		/// <returns>Retourne la liste des réservations</returns>
		public async Task<IEnumerable<Reservation>> GetAllAsync()
		{
			var stmt = @"select * from reservation";
			return await _session.Connection.QueryAsync<Reservation>(stmt, null, _session.Transaction);
		}


		/// <summary>
		///¨Permet d'obtenir une réservation présente en BDD en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne la reservation identifiée</returns>
		public async Task<Reservation> GetAsync(int id)
		{
			var stmt = @"select * from reservation where IdReservation = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Reservation>(stmt, new { Id = id }, _session.Transaction);
		}



		/// <summary>
		/// Permet de mettre à jour une réservation en BDD
		/// </summary>
		/// <param name="reservationToUpdate"></param>
		/// <returns>Retourne une boolean en fonction du succes de la mise a jour</returns>
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



		/// <summary>
		/// Permet d'ajouter une reservation en BDD
		/// </summary>
		/// <param name="reservationToCreate"></param>
		/// <returns>Retourne  la réservation nouvellement créée</returns>
		public async Task<Reservation> InsertAsyncs(ReservationsFilterRequest rfr)
		{
			var stmt = @"insert into Reservation(DateReservation,Entree,Plat,Dessert,NbPersonnes,IdService,IdClient) output INSERTED.IdReservation
						values(@DateReservation,@Entree,@Plat,@Dessert,@NbPersonnes,@IdService,@IdClient);";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, param: new {

				IdClient= rfr.idClient,
				IdService = rfr.IdService,
				DateReservation = DateTime.Now,
				NbPersonnes = rfr.NbPersonne,
				Entree = rfr.Entree,
				Plat = rfr.Plat,
				Dessert = rfr.Dessert


				}, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}


		public async Task<Reservation> InsertAsync(Reservation reservation)
		{
			var stmt = @"insert into Reservation(DateReservation,Entree,Plat,Dessert,NbPersonnes,IdService,IdClient) output INSERTED.IdReservation
						values(@date,@entree,@plat,@dessert,@nbpersonnes,@idservice,@idclient);";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt,reservation, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}



		/// <summary>
		/// Permet de supprimer une reservation à partir de son identifiant
		/// </summary>
		/// <param name="idReservation"></param>
		/// <returns>Retourne un boolean en fonction du succes de la suppression</returns>
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


		/// <summary>
		/// Permet d'obtenir la liste de toutes les reservations de façon paginée
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Retourne la liste des reservations de façon paginée</returns>
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
