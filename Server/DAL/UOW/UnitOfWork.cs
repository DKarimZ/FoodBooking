using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{

	/// <summary>
	/// Classe UnitOfwork ou sont définies les méthodes propres aux transactions
	/// </summary>
	sealed class UnitOfWork :IUnitOfWork
	{
		private readonly DbSession _session;
		private readonly IServiceProvider _serviceProvider;

		public UnitOfWork(DbSession session, IServiceProvider serviceProvider)
		{
			_session = session;
			this._serviceProvider = serviceProvider;
		}

		public void BeginTransaction()
		{
			_session.Transaction = _session.Connection.BeginTransaction();
		}

		public void Commit()
		{
			_session.Transaction.Commit();
			Dispose();
			
		}

		public void Rollback()
		{
			_session.Transaction.Rollback();
			Dispose();
		}

		public void Dispose() => _session.Transaction?.Dispose();

		public T GetRepository<T>() where T : class
		{
			return _serviceProvider.GetRequiredService<T>();

		}

	}
}
