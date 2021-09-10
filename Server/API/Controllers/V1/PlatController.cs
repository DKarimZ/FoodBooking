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
	[Route("api/v{version:apiVersion}/plats")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]
	//[Authorize(Roles = "Restaurateur, user")]

	public class PlatController : ControllerBase
	{
		private readonly IRestaurationService _restaurationService = null;

		public PlatController(IRestaurationService restaurationService)
		{
			_restaurationService = restaurationService;
		}

		/// <summary>
		/// Permet de récupérer tous les plats du restuarant
		/// </summary>
		/// <param name="pagerequest"></param>
		/// <returns>Retourne tous les plats et un message 200 si succès</returns>
		[HttpGet("request")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PageResponse<Plat>>> GetAllPlats([FromQuery] PageRequest pagerequest)
		{
			return Ok(await _restaurationService.GetAllPlats(pagerequest));
		}

		/// <summary>
		/// Permet de récupérer la liste des plats
		/// </summary>
		/// <param name="platrequest"></param>
		/// <returns>retourne le liste des plats</returns>
		[HttpGet("All")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PageResponse<Plat>>> GetAllPlats([FromQuery] Service serviceRequest)
		{
			if(serviceRequest.dateJourservice != null && serviceRequest.Midi != null )
			{
				return Ok(await _restaurationService.GetAllPlatsByDayAndService(serviceRequest.dateJourservice, serviceRequest.Midi));
			}
			else
			{
				return Ok(await _restaurationService.GetAllPlats());		
			}
		}

		/// <summary>
		/// Permet de Trier les plats en fonction de leur score de popularité
		/// </summary>
		/// <param name="platRequest"></param>
		/// <returns></returns>
		[HttpGet("pop")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Plat>> GetAllPlatsScore([FromQuery] Plat platRequest)
		{
			return Ok(await _restaurationService.GetAllPlatsScore());
		}

		/// <summary>
		/// Permet de récupérer tous les plats comportant un ingrédient dont selon son identifiant
		/// </summary>
		/// <param name="IdIngredient"></param>
		/// <returns>Retourne 200 si les plats contenant l'ingredient choisi ont bien été retournés</returns>
		[HttpGet("ingredientATrouver/{IdIngredient}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<Plat>>> GetAllPlatsByIngredient([FromRoute] int IdIngredient)
		{
			return Ok(await _restaurationService.GetAllPlatsByIngredients(IdIngredient));
		}


		/// <summary>
		/// Permet de filtrer les plats en fonction du type de plat(entrée, plat et dessert)
		/// </summary>
		/// <param name="idType"></param>
		/// <returns>Retourne 200 si les plats ont bien été triés par type et récupérés</returns>
		[HttpGet("type/{idType}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PageResponse<Plat>>> GetAllPlats([FromRoute] int idType)
		{
			return Ok(await _restaurationService.GetAllPlatsByType(idType));
		}


		/// <summary>
		/// Permet de récupérer une pageResponse de plats selon la date et le service
		/// </summary>
		/// <param name="date"></param>
		/// <param name="midi"></param>
		/// <returns>Retourne 200 si les plats ont bien été récupérés</returns>
		[HttpGet("byService")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PageResponse<Plat>>> GetAllPlatsByDateandMidi([FromQuery] DateTime date, bool midi)
		{
			return Ok(await _restaurationService.GetAllPlatsByDayAndService(date, midi));
		}




		/// <summary>
		/// Permet de récupérer un plat en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>retourne un plat</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		
		public async Task<IActionResult> GetPlatById([FromRoute] int id)
		{
			Plat plat = await _restaurationService.GetPlatById(id);
			if (plat == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(plat); // StatusCode = 200
			}
		}


		/// <summary>
		/// Permet de créer un nouveau plat en BDD
		/// </summary>
		/// <param name="plat"></param>
		/// <returns>Retourne le nouveau plat avec l'identifiant généré</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreatePlat([FromBody] Plat plat)
		{
			// Ajout du plat avec la bll server
			Plat newPlat = await _restaurationService.CreatePlat(plat);
			if (newPlat != null)
			{
				// Créer une redirection vers GetPlatById(newplat.IdPlat);
				return CreatedAtAction(nameof(GetPlatById),  new { id = newPlat.IdPlat }, newPlat);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}


		/// <summary>
		/// Permet de supprimer un plat en BDD
		/// </summary>
		/// <param name="idPlat"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
	
		public async Task<IActionResult> DeletePlat([FromRoute] int id)
		{
			if (await _restaurationService.RemovePlat(id))
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
		/// Permet de modifier un plat en BDD
		/// </summary>
		/// <param name="idPlat"></param>
		/// <param name="plat"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ModifyPlat([FromRoute] int id, [FromBody] Plat plat)
		{
			if (plat == null || id != plat.IdPlat)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Plat platModified = await _restaurationService.UpdatePlat(plat);
				if (platModified != null)
				{
					// Renvoie la ressource modifiée
					return Ok(platModified);
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
