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
	public class PlatControllerUnitTest
	{

		[Fact]

		public async void TestGetAllPlats()
		{

			IRestaurationService restaurationService = new FakeRestaurationService();
			PlatController platController = new PlatController(restaurationService);

			PageRequest pageRequest = new PageRequest()
			{
				Page = 1,
				PageSize = 10
			};

			PageRequest wrongpageRequest = new PageRequest()
			{
				Page = 8,
				PageSize = 30
			};

			ActionResult<PageResponse<Plat>> platOkresult = await platController.GetAllPlats(pageRequest);
			ActionResult<PageResponse<Plat>> platwrongresult = await platController.GetAllPlats(wrongpageRequest);

			Assert.NotNull(platOkresult);
			Assert.NotNull(platwrongresult);

		}

		[Fact]
		public async void  TestGetPlatById()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			PlatController platController = new PlatController(restaurationService);

			OkObjectResult	OkplatResult = await platController.GetPlatById(1) as OkObjectResult;
			NotFoundResult notfoundplatresult = await platController.GetPlatById(1789) as NotFoundResult;

			Assert.NotNull(OkplatResult);
			Assert.Equal(200, OkplatResult.StatusCode);

			Assert.NotNull(notfoundplatresult);
			Assert.Equal(404, notfoundplatresult.StatusCode);


		}

		[Fact]

		public async void TestcreatePlat()
		{

			IRestaurationService restaurationService = new FakeRestaurationService();
			PlatController platController = new PlatController(restaurationService);

			Plat newPlat = new Plat()
			{
				IdPlat = 10,
				nomPlat = "boeuf aux carottes et oignons",
				Score = 1,
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { IdIngredient = 11, nomIngredient = "boeuf", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 12, nomIngredient = "carotte", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 13, nomIngredient = "oignons", prixMoyen = 12 }
				}
			};

			Plat newbadPlat = new Plat()
			{
				IdPlat = 11,
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { IdIngredient = 11, nomIngredient = "boeuf", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 12, nomIngredient = "carotte", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 13, nomIngredient = "oignons", prixMoyen = 12 }
				}
			};

			CreatedAtActionResult platcreatedResult = await platController.CreatePlat(newPlat) as CreatedAtActionResult;
			BadRequestResult platnotcreatedresult = await platController.CreatePlat(newbadPlat) as BadRequestResult;

			Assert.NotNull(platcreatedResult);
			Assert.Equal(201, platcreatedResult.StatusCode);

			Assert.NotNull(platnotcreatedresult);
			Assert.Equal(400, platnotcreatedresult.StatusCode);

		}
		

		[Fact]
		public async void TestDeletePlat()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			PlatController platController = new PlatController(restaurationService);

			NoContentResult platdeleteResult = await platController.DeletePlat(1) as NoContentResult;
			NotFoundResult platnotfoundResult = await platController.DeletePlat(789) as NotFoundResult;

			Assert.NotNull(platdeleteResult);
			Assert.Equal(204, platdeleteResult.StatusCode);

			Assert.NotNull(platnotfoundResult);
			Assert.Equal(404, platnotfoundResult.StatusCode);


		}

		public async void TestModifyPlat()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			PlatController platController = new PlatController(restaurationService);

			Plat platUpdated = new Plat()
			{
				nomPlat = "boeuf aux carottes",
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { IdIngredient = 11, nomIngredient = "boeuf", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 12, nomIngredient = "carotte", prixMoyen = 12 },
					new Ingredient() { IdIngredient = 13, nomIngredient = "oignons", prixMoyen = 12 }
				}
			};

			OkObjectResult OkplatUpdatedresult = await platController.ModifyPlat(11, platUpdated) as OkObjectResult;
			BadRequestResult platbadrequestresult = await platController.ModifyPlat(1345, platUpdated) as BadRequestResult;
			NotFoundObjectResult platnotFoundresult = await platController.ModifyPlat(11, null) as NotFoundObjectResult;

			Assert.NotNull(OkplatUpdatedresult);
			Assert.Equal(200, OkplatUpdatedresult.StatusCode);

			Assert.NotNull(platnotFoundresult);
			Assert.Equal(404, platnotFoundresult.StatusCode);

			Assert.NotNull(platbadrequestresult);
			Assert.Equal(400, platbadrequestresult.StatusCode);

		}

	}
}
