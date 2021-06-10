using BLL.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/ingredients")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]
	[Authorize(Roles = "Restaurateur")]

	public class IngredientController : ControllerBase
	{
		private readonly IRestaurationService _restaurationService = null;

		public IngredientController(IRestaurationService restaurationService)
		{
			_restaurationService = restaurationService;
		}


		/// <summary>
		/// Permet de récupérer la liste des ingrédients
		/// </summary>
		/// <param name="ingredientrequest"></param>
		/// <returns>retourne la liste des ingrédients</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PageResponse<Ingredient>>> GetAllIngredients([FromQuery] PageRequest pagerequest)
		{
			return Ok(await _restaurationService.GetAllIngredients(pagerequest));
		}


		/// <summary>
		/// Permet de récupérer un ingrédient en fonction de son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>retourne un ingrédient en particulier</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetingredienttById([FromRoute] int id)
		{
			Ingredient ingredient = await _restaurationService.GetIngredientById(id);
			if (ingredient == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(ingredient); // StatusCode = 200
			}
		}


		/// <summary>
		/// Permet de créer un ingrédient en BDD
		/// </summary>
		/// <param name="ingredient"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateIngredient([FromBody] Ingredient ingredient)
		{
			// Ajout de l'ingrédient avec la bll server
			Ingredient newIngredient= await _restaurationService.CreateIngredient(ingredient);
			if (newIngredient != null)
			{
				// Créer une redirection vers GetIngredientById(newIngredient.Idingredient);
				return CreatedAtAction(nameof(GetingredienttById), new { id = newIngredient.IdIngredient }, newIngredient);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}


		/// <summary>
		/// Permet de supprimer un igrédient en BDD
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Deleteingredient([FromRoute] int idIngredient)
		{
			if (await _restaurationService.RemoveIngredient(idIngredient))
			{
				// Renvoie un code 204 aucun contenu
				return NoContent();
			}
			else
			{
				// Renvoie un code 404: la ressource est introuvable
				return NotFound();
			}
		}


		/// <summary>
		/// Permet de modifier un ingrédient en BDD
		/// </summary>
		/// <param name="idIngredient"></param>
		/// <param name="ingredient"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Modifyingredient([FromRoute] int idIngredient, [FromBody] Ingredient ingredient)
		{
			if (ingredient == null || idIngredient != ingredient.IdIngredient)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Ingredient ingredientModified = await _restaurationService.UpdateIngredient(ingredient);
				if (ingredientModified != null)
				{
					// Renvoie la ressource modifiée
					return Ok(ingredientModified);
				}
				else
				{
					// Renvoie un code 404: la ressource est introuvable
					return NotFound();
				}
			}
		}



	}
}
