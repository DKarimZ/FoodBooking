using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Services;
using Xunit;

namespace UnitTest
{
	public class RestaurationServiceUnitTest
	{

		[Fact]
		public void GetAllMenusTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			

		}
	}
}
