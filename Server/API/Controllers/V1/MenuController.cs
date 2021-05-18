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
	[Route("api/v{version:apiVersion}/menus")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]

	public class MenuController : ControllerBase
	{
		private readonly IRestaurationService _restaurationService = null;

		public MenuController(IRestaurationService restaurationService)
		{
			_restaurationService = restaurationService;
		}

		/// <summary>
		/// Permet de récupérer la liste des menus
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>retourne la liste des plats</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Menu>> GetAllMenus([FromQuery] Menu menuRequest)
		{
			return Ok(await _restaurationService.GetAllMenus());
		}

		/// <summary>
		/// Permet de retourner un livre en fonction de son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>retourne un livre en particulier</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetMenuById([FromRoute] int id)
		{
			Menu menu = await _restaurationService.GetMenuById(id);
			if (menu == null)
			{
				return NotFound(); // StatusCode = 404
			}
			else
			{
				return Ok(menu); // StatusCode = 200
			}
		}


		/// <summary>
		/// Permet de créer un menu en BDD
		/// </summary>
		/// <param name="menu"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
		{
			// Ajout du menu avec la bll server
			Menu newMenu = await _restaurationService.CreateMenu(menu);
			if (newMenu != null )
			{
				// Créer une redirection vers GetMenuById(newMenu.IdMenu);
				return CreatedAtAction(nameof(GetMenuById), new { id = newMenu.IdMenu }, newMenu);
			}
			else
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
		}

		/// <summary>
		/// Permet de supprimer un menu en BDD
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>retourne un code en fonction du résultat</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteMenu([FromRoute] int idMenu)
		{
			if (await _restaurationService.RemoveMenu(idMenu))
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
		/// <param name="menu"></param>
		/// <returns>retroune un code en fonction du résultat</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ModifyMenu([FromRoute] int idMenu, [FromBody] Menu menu)
		{
			if (menu == null || idMenu != menu.IdMenu)
			{
				// Retourne un code 400  Bad Request
				return BadRequest();
			}
			else
			{
				Menu menuModified = await _restaurationService.UpdateMenu(menu);
				if (menuModified != null)
				{
					// Renvoie la ressource modifiée
					return Ok(menuModified);
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
