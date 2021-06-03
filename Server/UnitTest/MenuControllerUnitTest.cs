using API.Controllers.V1;
using BLL.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Services;
using Xunit;

namespace UnitTest
{
	public class MenuControllerUnitTest
	{
		#region TestMenu

		[Fact]
		public async void TestGetMenuById()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			ServiceController menuController = new ServiceController(restaurationService);

			OkObjectResult menuActionresult = await menuController.GetServiceById(1) as OkObjectResult;
			NotFoundResult NotFoundmenuActionResult = await menuController.GetServiceById(567) as NotFoundResult;

			Assert.NotNull(menuActionresult);
			Assert.Equal(200, menuActionresult.StatusCode);

			Assert.NotNull(NotFoundmenuActionResult);
			Assert.Equal(404, NotFoundmenuActionResult.StatusCode);

		}

		[Fact]
		public async void TestGetAllMenus()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			ServiceController menuController = new ServiceController(restaurationService);

			Service menu = new Service();

			ActionResult<Service> menuActionresult = await menuController.GetAllServices(menu);
			ActionResult<Service> wrongmenuActionresult = await menuController.GetAllServices(menu);

			Assert.NotNull(menuActionresult);
			Assert.NotNull(wrongmenuActionresult);

		}

		[Fact]
		public async void TestCreateMenu()
			{
			Service newMenu = new Service()
			{
				IdService = 8,
				Midi = true,
				dateJourservice = new DateTime(2021,06,13)
			};

			Service wrongMenu = new Service()
			{
				IdService = 9,
				Midi = false
			};

			IRestaurationService restaurationService = new FakeRestaurationService();
			ServiceController menuController = new ServiceController(restaurationService);

			CreatedAtActionResult menuActionResult = await menuController.CreateService(newMenu) as CreatedAtActionResult;
			BadRequestResult badrequestMenu = await menuController.CreateService(wrongMenu) as BadRequestResult;

			Assert.NotNull(menuActionResult);
			Assert.Equal(201, menuActionResult.StatusCode);

			Assert.NotNull(badrequestMenu);
			Assert.Equal(400, badrequestMenu.StatusCode);
		}

		[Fact]
		public async void TestDeleteMenu()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			ServiceController menuController = new ServiceController(restaurationService);

			NoContentResult noContentExpected = await menuController.DeleteService(1) as NoContentResult;
			NotFoundResult nofoundExpected = await menuController.DeleteService(7898) as NotFoundResult;

			Assert.NotNull(noContentExpected);
			Assert.Equal(204, noContentExpected.StatusCode);

			Assert.NotNull(nofoundExpected);
			Assert.Equal(404, nofoundExpected.StatusCode);

		}

		#endregion


	}
}
