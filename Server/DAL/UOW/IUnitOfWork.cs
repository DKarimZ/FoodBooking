using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{

	/// <summary>
	/// Interface IUnitOfWork avec les opérations concernant les transactions
	/// </summary>

	public interface IUnitOfWork : IDisposable
	{
		void BeginTransaction();
		void Commit();
		void Rollback();
		T GetRepository<T>() where T : class;
	}
}
