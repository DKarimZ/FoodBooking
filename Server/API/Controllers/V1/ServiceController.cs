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
	[Route("api/v{version:apiVersion}/services")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]
//	[Authorize(Roles = "Restaurateur")]

	public class ServiceController : ControllerBase
	{
		private readonly IRestaurationService _restaurationService = null;

		public ServiceController(IRestaurationService restaurationService)
		{
			_restaurationService = restaurationService;
		}


		/// <summary>
		/// Permet de récupérer la liste des services
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>retourne la liste des plats</returns>
		[HttpGet("All")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Service>> GetAllServices([FromQuery] Service serviceRequest)
		{
			return Ok(await _restaurationService.GetAllServices());
		}


		/// <summary>
		/// Permet de récupérer un service en fonction de la date et du service (midi ou soir)
		/// </summary>
		/// <param name="date"></param>
		/// <param name="midi"></param>
		/// <returns>retourne le service et un message 200 si  succès s</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Service>> GetserviceByDateandMidi([FromQuery] DateTime date, bool midi)
		{
			if (date != null && midi!= null)
			{
				return Ok(await _restaurationService.GetServiceByDateAndMidi(date, midi));
			}

			else{
				return Ok(await _restaurationService.GetAllServices());
			}
		}

		/// <summary>
		/// Permet de récupérer un service en fonction de son identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>retourne le service et un message 200 si succès et 404 si erreur</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetServiceById([FromRoute] int id)
		{
			Service service = await _restaurationService.GetServiceById(id);
			if (service == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(service); // StatusCode = 200
			}
		}
 


		/// <summary>
		/// Permet de créer un menu en BDD
		/// </summary>
		/// <param name="service"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateService([FromBody] Service service)
		{
			// Ajout du service avec la bll server
			Service newService = await _restaurationService.CreateService(service);
			if (newService != null )
			{
				// Créer une redirection vers GetServiceById(newMenu.IdMenu);
				return CreatedAtAction(nameof(GetServiceById), new { id = newService.IdService }, newService);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}


		/// <summary>
		/// Permet de supprimer un service en BDD
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpDelete("{idService}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteService([FromRoute] int idService)
		{
			if (await _restaurationService.RemoveService(idService))
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
		/// Permet de modifier un livre en BDD
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="service"></param>
		/// <returns>retroune un code en fonction du résultat</returns>
		[HttpPut("{idService}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ModifyService([FromRoute] int idService, [FromBody] Service service)
		{
			if (service == null || idService != service.IdService)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Service serviceModified = await _restaurationService.UpdateService(service);
				if (serviceModified != null)
				{
					// Renvoie la ressource modifiée
					return Ok(serviceModified);
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
