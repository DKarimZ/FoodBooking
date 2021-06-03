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
	public class RestaurationServiceUnitTest
	{


		#region TestMenu

		[Fact]
		public async void GetAllMenusTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Service menu = new Service();

			List<Service> menuActionresult = await restaurationService.GetAllServices();

			Assert.NotNull(menuActionresult);
		}


		[Fact]

		public async void GetMenuByIdTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Service menugoodResult = await restaurationService.GetServiceById(5);
			Service menubadResult = await restaurationService.GetServiceById(159);

			Assert.NotNull(menugoodResult);
			Assert.Null(menubadResult);
		}

		[Fact]

		public async void CreateMenuTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Service newService = new Service();


			Service menuCreateGood = await restaurationService.CreateService(newService);

			Assert.NotNull(menuCreateGood);

		}

		[Fact]

		public async void UpdateMenuTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Service menu = new Service()
			{
				IdService = 3,
				Midi = true,
				dateJourservice = new ()

			};

			Service updateMenuSuccess = await restaurationService.UpdateService(menu);
			Service updateMenuFailed = await restaurationService.UpdateService(null);

			Assert.NotNull(updateMenuSuccess);
			Assert.Null(updateMenuFailed);


		}

		#endregion

		#region TestPlat

		[Fact]
		public async void GetAllPlatsTest()
		{
			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			PageRequest pageRequest = new PageRequest()
			{
				Page = 1,
				PageSize = 5
			};


			PageResponse<Plat> pageresponse = await restaurationService.GetAllPlats(pageRequest);

			Assert.NotNull(pageresponse);

		}

		[Fact]

		public async void GetPlatByIdTest()
		{

			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Plat platgoodResult = await restaurationService.GetPlatById(5);
			Plat platbadResult = await restaurationService.GetPlatById(159);

			Assert.NotNull(platgoodResult);
			Assert.Null(platbadResult);
		}

		[Fact]
		public async void CreatePlatTest()
		{


			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Plat newPlat = new Plat();


			Plat platCreateGood = await restaurationService.CreatePlat(newPlat);

			Assert.NotNull(platCreateGood);



		}

		[Fact]
		public async void UpdatePlatTest()
		{

			IRestaurationService restaurationService = new RestaurationService(new FakeUnitOfwork());

			Plat plat = new Plat()
			{
				IdPlat = 3,
				nomPlat = "Bouillabaisse",
				Score = 1,
				PlatIngredient = new List<PlatIngredient>()

			};

			Plat updatePlatSuccess = await restaurationService.UpdatePlat(plat);
			Plat updateplatFailed = await restaurationService.UpdatePlat(null);

			Assert.NotNull(updatePlatSuccess);
			Assert.Null(updateplatFailed);

		}

		#endregion

		#region
		#endregion


	}
}