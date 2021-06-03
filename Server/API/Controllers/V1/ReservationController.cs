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
	[Route("api/v{version:apiVersion}/reservations")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]

	public class ReservationController : ControllerBase
	{
		private readonly IReservationService _reservationService = null;

		public ReservationController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}

		/// <summary>
		/// Permet de r�cup�rer la liste des r�servations
		/// </summary>
		/// <param name="reservationrequest"></param>
		/// <returns>retourne la liste des r�servations</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = "Restaurateur")]
		public async Task<ActionResult<Reservation>> GetAllreservations([FromQuery] Reservation reservationrequest)
		{
			return Ok(await _reservationService.GetAllReservations());
		}

		/// <summary>
		/// Permet de r�cup�rer une r�servation avec son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>retourne une r�servation</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = "Restaurateur")]
		public async Task<IActionResult> GetReservationById([FromRoute] int id)
		{
			Reservation reservation = await _reservationService.GetReservationById(id);
			if (reservation == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(reservation); // StatusCode = 200
			}
		}

		/// <summary>
		/// Permet de cr�er une nouvelle r�servation en BDD
		/// </summary>
		/// <param name="reservation"></param>
		/// <returns>retourne une r�servation</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = "user, restaurateur")]
		public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
		{
			// Ajout de la r�servation avec la bll server
			Reservation newReservation = await _reservationService.CreateReservation(reservation);
			if (newReservation != null)
			{
				// Cr�er une redirection vers GetReservationById(newreservation.ReservationId);
				return CreatedAtAction(nameof(GetReservationById), new { id = newReservation.IdReservation}, newReservation);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}

		/// <summary>
		/// Permet de supprimer une r�servation en BDD en fonction de son Identifiant
		/// </summary>
		/// <param name="idReservation"></param>
		/// <returns>Retourne un code selon le r�sultat</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = "Restaurateur")]
		public async Task<IActionResult> DeleteReservation([FromRoute] int idReservation)
		{
			if (await _reservationService.removeReservation(idReservation))
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
		/// Permet de mettre � jour un livre en BDD
		/// </summary>
		/// <param name="idReservation"></param>
		/// <param name="reservation"></param>
		/// <returns>Retourne un code en fonction du r�sultat</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = "Restaurateur")]
		public async Task<IActionResult> ModifyReservation([FromRoute] int idReservation, [FromBody] Reservation reservation)
		{
			if (reservation == null || idReservation != reservation.IdReservation)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Reservation reservationModified = await _reservationService.ModifyReservation(reservation);
				if (reservationModified != null)
				{
					// Renvoie la ressource modifi�e
					return Ok(reservationModified);
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
