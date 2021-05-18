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
	class PlatRepository : IPlatRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<MenuRepository> _logger;

		public PlatRepository(DbSession session, ILogger<MenuRepository> logger)
		{
			_session = session;
			_logger = logger;
		}
		public async Task<IEnumerable<Plat>> GetAllAsync()
		{
			var stmt = @"select * from plat";
			return await _session.Connection.QueryAsync<Plat>(stmt, null, _session.Transaction);
		}
		public async Task<Plat> GetAsync(int id)
		{
			var stmt = @"select * from plat where id = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<Plat>(stmt, new { Id = id }, _session.Transaction);
		}
		public async Task<bool> UpdateAsync(Plat platToUpdate)
		{
			var stmt = @"update plat set nomPlat = @nomPlat, typePlat = @typePlat, score = @Score, Ingredients = @Ingredients from plat join ingredient where IdPlat = @IdPlat";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, platToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}
		public async Task<Plat> InsertAsync(Plat platToCreate)
		{
			var stmt = @"insert into plat(nomPlat,typePlat,Ingredients) output INSERTED.ID values (@nomPlat,@typePlat, @Ingredients)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, platToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}
		public async Task<bool> DeleteAsync(int idPlat)
		{
			var stmt = @"delete from plat where IdPlat = @IdPlat";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { idMenu = idPlat }, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;

			}
		}
		public async Task<PageResponse<Plat>> GetAllAsync(PageRequest pageRequest)
		{
			var stmt = @"select * from plat
						ORDER BY IdPlat
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNT(*) FROM plat ";

			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, pageRequest, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponse<Plat>(pageRequest.Page, pageRequest.PageSize, countTask, (platTask).ToList());
		}

		public async Task<PageResponseSortable<Plat>> GetAllAsync(PageRequestSortable pageRequestSortable)
		{
			var stmt = @"select * from plat
						ORDER BY Score
						OFFSET @PageSize * (@Page - 1) rows
						FETCH NEXT @PageSize rows only";

			string queryCount = " SELECT COUNT(*) FROM plat ";

			IEnumerable<Plat> platTask = await _session.Connection.QueryAsync<Plat>(stmt, pageRequestSortable, _session.Transaction);
			int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

			return new PageResponseSortable<Plat>(pageRequestSortable.Score, pageRequestSortable.Page, pageRequestSortable.PageSize, countTask, (platTask).ToList());

		}


		


	}
}
