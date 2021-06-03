using BO.Entity;
using DAL.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BO.DTO.Responses;
using BO.DTO.Requests;

namespace DAL.Repository
{
	class ServiceRepository : IServiceRepository
	{
		private readonly DbSession _session;
		private readonly ILogger<ServiceRepository> _logger;

		public ServiceRepository(DbSession session, ILogger<ServiceRepository> logger)
		{
			_session = session;
			_logger = logger;
		}

		public async Task <IEnumerable<Service>> GetAllAsync() 
		{
			var stmt = @"select * from Services";
			return await _session.Connection.QueryAsync<Service>(stmt, null, _session.Transaction);
		}
		public async Task<Service> GetAsync(int id) 
		{
			var stmt = @"select * from Services where IdService = @id";
			var r =  await _session.Connection.QueryFirstOrDefaultAsync<Service>(stmt, new { Id = id }, _session.Transaction);
			return r;
		}
		public async Task<bool> UpdateAsync(Service menuToUpdate)
		{
			var stmt = @"update menu set firstDayWeek = @firstDayweek, Plats = @Plats from menu join plat where IdMenu = @IdMenu";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, menuToUpdate, _session.Transaction);
				return i > 0;
			}
			catch
			{
				return false;
			}
		}
		public async Task<Service> InsertAsync(Service menuToCreate)
		{
			var stmt = @"insert into menu(firstDayweek, Plats) output INSERTED.ID values (@firstDayweek, @Plats)";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, menuToCreate, _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}
		public async Task<bool> DeleteAsync(int idMenu)
		{
			var stmt = @"delete from menu where IdMenu = @IdMenu";

			try
			{
				int i = await _session.Connection.ExecuteAsync(stmt, new { idMenu = idMenu }, _session.Transaction);
				return i > 0;
			}
			catch 
			{
				return false;
			
			}
		}

		//public async Task<PageResponse<Menu>> GetAllAsync(PageRequest pageRequest)
		//{
		//	var stmt = @"select * from menu
		//				ORDER BY IdMenu
		//				OFFSET @PageSize * (@Page - 1) rows
		//				FETCH NEXT @PageSize rows only";

		//	string queryCount = " SELECT COUNT(*) FROM menu ";

		//	IEnumerable<Menu> menuTask = await _session.Connection.QueryAsync<Menu>(stmt, pageRequest, _session.Transaction);
		//	int countTask = await _session.Connection.ExecuteScalarAsync<int>(queryCount, null, _session.Transaction);

		//	return new PageResponse<Menu>(pageRequest.Page, pageRequest.PageSize, countTask, (menuTask).ToList());
		//}

	}
}
