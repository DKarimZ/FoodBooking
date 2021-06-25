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
using BO.DTO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.V1
{

	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/commandes")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]
	[Authorize(Roles = "Restaurateur")]

	public class CommandeController : ControllerBase
	{
		private readonly IReservationService _reservationService = null;

		public CommandeController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}


		/// <summary>
		/// Permet de récupérer la liste des commandes
		/// </summary>
		/// <param name="commanderequest"></param>
		/// <returns>retourne la liste des commandes</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Commande>> GetAllCommandes([FromQuery] Commande commanderequest)
		{
			return Ok(await _reservationService.GetAllCommandes());
		}


		/// <summary>
		/// Permet de récupérer une commande en fonction de son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("afficher")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCommande([FromQuery] CommandDTO commandeRequest)
		{
			CommandDTO commande = await _reservationService.GetCommande();
			if (commande == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(commande); // StatusCode = 200
			}
		}


		/// <summary>
		/// Permet de créer une commande en BDD
		/// </summary>
		/// <param name="commande"></param>
		/// <returns>retourne la commande avec le nouvel identifiant généré</returns>
		//[HttpPost()]
		//[ProducesResponseType(StatusCodes.Status201Created)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		////public async Task<IActionResult> CreateCommande([FromBody] Commande commande)
		////{
		////	// Ajout de la commande avec la bll server
		////	Commande newCommande = await _reservationService.CreateCommande(commande);
		////	if (newCommande != null)
		////	{
		////		// Créer une redirection vers GetcommandeById(newCommande.IdCommande);
		////		return CreatedAtAction(nameof(GetCommandeById), new { id = newCommande.IdCommande }, newCommande);
		////	}
		////	else
		////	{
		////		// Retourne un code 400  Bad Request
		////		return BadRequest();
		////	}
		////}


	}



}

