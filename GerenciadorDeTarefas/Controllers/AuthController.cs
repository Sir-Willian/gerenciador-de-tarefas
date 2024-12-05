using GerenciadorDeTarefas.Helpers;
using GerenciadorDeTarefas.Model;
using GerenciadorDeTarefas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers;

[ApiController()]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	[HttpPost()]
	[AllowAnonymous()]
    #pragma warning disable CS1998
	public async Task<IActionResult> Auth([FromBody]User user)
	{
		try
		{
			var userExists = new UserRepository().GetByUserName(user.UserName);

			if (userExists == null) { return BadRequest(new { Message = "Nome de usuário e/ou senha está(ão) inválido(s)." }); }

			if (userExists.Password != user.Password) { return BadRequest(new { Message = "Nome de usuário e/ou senha está(ão) inválido(s)." }); }

			var token = JwtAuth.GenerateToken(userExists);

			return Ok(new
			{
				Token = token,
				Usuario = userExists
			});
		}
		catch (Exception) { return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." }); }
	}
}