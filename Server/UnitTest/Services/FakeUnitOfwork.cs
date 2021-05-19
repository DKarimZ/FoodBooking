using DAL.Repository;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{
	class FakeUnitOfwork : IUnitOfWork
	{

		public void BeginTransaction()
		{
			return;
		}

		public void Commit()
		{
			return;
		}

		public void Dispose()
		{
			return;
		}
		/// <summary>
		/// T => IMenuRepository, I
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetRepository<T>() where T : class
		{
			Type repository = typeof(T);

			if (repository == typeof(IMenuRepository))
			{
				return new FakeMenuRepository() as T;
			}
			else if (repository == typeof(IPlatRepository))
			{
				return new FakePlatRepository() as T;
			}
			else if (repository == typeof(IIngredientRepository))
			{
				return new FakeIngredientRepository() as T;
			}
			else return null;
		}

		public void Rollback()
		{
			return;
		}
	}
}
