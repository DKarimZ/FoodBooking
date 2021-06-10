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

namespace API.Controllers.V1
{

	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/clients")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]

	public class ClientController : ControllerBase
	{
		private readonly IReservationService _reservationService = null;

		public ClientController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}


		/// <summary>
		/// Permet de récupérer la liste des clients
		/// </summary>
		/// <param name="clientrequest"></param>
		/// <returns>retourne la liste des clients</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Client>> GetAllClients([FromQuery] Client clientrequest)
		{
			return Ok(await _reservationService.GetAllClients());
		}


		/// <summary>
		/// Permet de récupérer un client en fonction de son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetClientById([FromRoute] int id)
		{
			Client client = await _reservationService.GetClientById(id);
			if (client == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(client); // StatusCode = 200
			}
		}


		/// <summary>
		/// Permet de créer un client en BDD
		/// </summary>
		/// <param name="client"></param>
		/// <returns>retourne le nouveau client avec l'Identifiant généré</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateClient([FromBody] Client client)
		{
			// Ajout du client avec la bll server
			Client newClient = await _reservationService.CreateClient(client);
			if (newClient != null)
			{
				// Créer une redirection vers GetClientById(newclient.ClientId);
				return CreatedAtAction(nameof(GetClientById), new { id = newClient.IdClient }, newClient);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}


		/// <summary>
		/// Permet de supprimer un client en BDD
		/// </summary>
		/// <param name="idClient"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
		{
			if (await _reservationService.RemoveClientById(idClient))
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
		/// Permet de modifier un client en BDD
		/// </summary>
		/// <param name="idClient"></param>
		/// <param name="client"></param>
		/// <returns>retourne un code en fonction du résultat </returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ModifyClient([FromRoute] int idClient, [FromBody] Client client)
		{
			if (client == null || idClient != client.IdClient)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Client clientModified = await _reservationService.ModifyClient(client);
				if (clientModified != null)
				{
					// Renvoie la ressource modifiée
					return Ok(clientModified);
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
