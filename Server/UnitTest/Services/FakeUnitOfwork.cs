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
			switch (repository)
			{
				case IMenuRepository:
					return new FakeMenuRepository() as T;

				case IPlatRepository:
					return new FakePlatRepository() as T;

				case IIngredientRepository:
					return new FakeIngredientRepository() as T;

				default:
					return null;

			}

		}

		public void Rollback()
		{
			return;
		}
	}
}
