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
	/// <summary>
	/// Testing the Ingredient controller / methods
	/// </summary>
	public class IngredientcontrollerUnitTest
	{
		[Fact]

		public async void TestGetAllIngredients()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			IngredientController ingredientController = new IngredientController(restaurationService);

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

			ActionResult<PageResponse<Ingredient>> ingredientActionresult = await ingredientController.GetAllIngredients(pageRequest);
			ActionResult<PageResponse<Ingredient>> wrongIngredientActionresult = await ingredientController.GetAllIngredients(wrongpageRequest);

			Assert.NotNull(ingredientActionresult);
			Assert.NotNull(wrongIngredientActionresult);

		}

		[Fact]
		public async void TestGetIngredientById()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			IngredientController ingredientController = new IngredientController(restaurationService);

			OkObjectResult ingredientresult = await ingredientController.GetingredienttById(3) as OkObjectResult;
			NotFoundResult ingredientnotfoundResult = await ingredientController.GetingredienttById(1678) as NotFoundResult;

			Assert.NotNull(ingredientresult);
			Assert.Equal(200, ingredientresult.StatusCode);

			Assert.NotNull(ingredientnotfoundResult);
			Assert.Equal(404, ingredientnotfoundResult.StatusCode);

		}

		[Fact]

		public async void TestCreateIngredient()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			IngredientController ingredientController = new IngredientController(restaurationService);

			Ingredient newIngredient = new Ingredient()
			{
				IdIngredient = 5,
				NomIngredient = "saumon",
				PrixMoyen = 14
			};

			Ingredient newbadIngredient = new Ingredient()
			{
				IdIngredient = 6,
				PrixMoyen = 18
			};

			CreatedAtActionResult ingredientcreatedResult = await ingredientController.CreateIngredient(newIngredient) as CreatedAtActionResult;
			BadRequestResult  ingredientnotcreatedresult  = await ingredientController.CreateIngredient(newbadIngredient) as BadRequestResult;

			Assert.NotNull(ingredientcreatedResult);
			Assert.Equal(201, ingredientcreatedResult.StatusCode);

			Assert.NotNull(ingredientnotcreatedresult);
			Assert.Equal(400, ingredientnotcreatedresult.StatusCode);
		}

		[Fact]
		public async void TestDeleteIngredient()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			IngredientController ingredientController = new IngredientController(restaurationService);

			NoContentResult ingredientdeleteResult = await ingredientController.Deleteingredient(3) as NoContentResult;
			NotFoundResult ingredientnotfoundResult = await ingredientController.Deleteingredient(789) as NotFoundResult;

			Assert.NotNull(ingredientdeleteResult);
			Assert.Equal(204, ingredientdeleteResult.StatusCode);

			Assert.NotNull(ingredientnotfoundResult);
			Assert.Equal(404, ingredientnotfoundResult.StatusCode);

		}

		[Fact]
		public async void TestModifyIngredient()
		{
			IRestaurationService restaurationService = new FakeRestaurationService();
			IngredientController ingredientController = new IngredientController(restaurationService);

			Ingredient ingredientupdated = new Ingredient()
			{
				IdIngredient = 3,
				NomIngredient = "tomatoes",
				PrixMoyen = 5

			};

			OkObjectResult ingredientUpdatedresult = await ingredientController.Modifyingredient(3, ingredientupdated) as OkObjectResult;
			BadRequestResult ingredientbadRequestresult = await ingredientController.Modifyingredient(167, ingredientupdated) as BadRequestResult;

			Assert.NotNull(ingredientUpdatedresult);
			Assert.Equal(200, ingredientUpdatedresult.StatusCode);

			Assert.NotNull(ingredientbadRequestresult);
			Assert.Equal(400, ingredientbadRequestresult.StatusCode);


		}





	}
}
