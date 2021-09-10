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
	public class PlatIngredientRepository : IPlatIngredientRepository
	{

		private readonly DbSession _session;
		private readonly ILogger<PlatIngredientRepository> _logger;

		public PlatIngredientRepository(DbSession session, ILogger<PlatIngredientRepository> logger)
		{
			_session = session;
			_logger = logger;
		}

		public async Task<PlatIngredient> GetAsync(int id)
		{
			var stmt = @"select * from PlatIngredient where IdPlat = @id";
			return await _session.Connection.QueryFirstOrDefaultAsync<PlatIngredient>(stmt, new { @id = id }, _session.Transaction);
		}


		public async Task<PlatIngredient> InsertAsync( PlatIngredient platIngredientToAdd)
		{
			var stmt = @"insert into PlatIngredient(IdIngredient, Quantite) output INSERTED.IdPlat ( @IdIngredient, @Quantite);";
			try
			{
				int i = await _session.Connection.QuerySingleAsync<int>(stmt, platIngredientToAdd , _session.Transaction);
				return await GetAsync(i);
			}
			catch
			{
				return null;
			}
		}


		//public async Task<bool> DeleteAllIngredientsOfDish(int IdPlat)
		//{

		//	var stmt = $"delete from PlatIngredient where IdPlat = @IdPlat";

		//}

	}
}
