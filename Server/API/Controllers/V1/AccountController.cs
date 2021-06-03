using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BO.DTO.Responses;
using BO.DTO.Requests;

namespace API.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:ApiVersion}/account")]
	[Produces(MediaTypeNames.Application.Json)]
	[Consumes(MediaTypeNames.Application.Json)]
	[AllowAnonymous]
	
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;

		}

		[HttpPost("login")]
		[AllowAnonymous]

		public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
		{
			LoginResponse loginResponse = await _accountService.Login(loginRequest.Username, loginRequest.Password);
			if (loginResponse != null)
			{
				return Ok(loginResponse);
			}
			else
			{
				return Unauthorized();

			}

		}


	}
}
