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
			MenuController menuController = new MenuController(restaurationService);

			OkObjectResult menuActionresult = await menuController.GetMenuById(1) as OkObjectResult;
			NotFoundResult NotFoundmenuActionResult = await menuController.GetMenuById(567) as NotFoundResult;

			Assert.NotNull(menuActionresult);
			Assert.Equal(200, menuActionresult.StatusCode);

			Assert.NotNull(NotFoundmenuActionResult);
			Assert.Equal(404, NotFoundmenuActionResult.StatusCode);

		}

		[Fact]
		public async void TestGetAllMenus()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			MenuController menuController = new MenuController(restaurationService);

			Menu menu = new Menu();

			//PageRequest pageRequest = new PageRequest()
			//{
			//	Page = 1,
			//	PageSize = 10
			//};

			//PageRequest wrongpageRequest = new PageRequest()
			//{
			//	Page = 8,
			//	PageSize = 30
			//};

			ActionResult<Menu> menuActionresult = await menuController.GetAllMenus(menu);
			ActionResult<Menu> wrongmenuActionresult = await menuController.GetAllMenus(menu);

			Assert.NotNull(menuActionresult);
			Assert.NotNull(wrongmenuActionresult);

		}

		[Fact]
		public async void TestCreateMenu()
			{
			Menu newMenu = new Menu()
			{
				IdMenu = 8,
				firstDayweek = "Mardi",
				Plats = new Plat()
			};

			Menu wrongMenu = new Menu()
			{
				IdMenu = 9,
				Plats = new Plat()
			};

			IRestaurationService restaurationService = new FakeRestaurationService();
			MenuController menuController = new MenuController(restaurationService);

			CreatedAtActionResult menuActionResult = await menuController.CreateMenu(newMenu) as CreatedAtActionResult;
			BadRequestResult badrequestMenu = await menuController.CreateMenu(wrongMenu) as BadRequestResult;

			Assert.NotNull(menuActionResult);
			Assert.Equal(201, menuActionResult.StatusCode);

			Assert.NotNull(badrequestMenu);
			Assert.Equal(400, badrequestMenu.StatusCode);
		}

		[Fact]
		public async void TestDeleteMenu()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			MenuController menuController = new MenuController(restaurationService);

			NoContentResult noContentExpected = await menuController.DeleteMenu(1) as NoContentResult;
			NotFoundResult nofoundExpected = await menuController.DeleteMenu(7898) as NotFoundResult;

			Assert.NotNull(noContentExpected);
			Assert.Equal(204, noContentExpected.StatusCode);

			Assert.NotNull(nofoundExpected);
			Assert.Equal(404, nofoundExpected.StatusCode);

		}

		#endregion


	}
}
