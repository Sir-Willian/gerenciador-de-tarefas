using GerenciadorDeTarefas.Model;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorDeTarefas.Helpers;

public static class JwtAuth
{
	public static IConfiguration Configuration { get; set; } = default!;

	public static string GenerateToken(User user)
	{
		var myClaims = new[]
		{
			new Claim(ClaimTypes.Name, user.UserName),
			new Claim(ClaimTypes.Role, RoleFactory(user.Type))
		};

        #pragma warning disable CS8604
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]));
		var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

		var token = new JwtSecurityToken(
			issuer: Configuration["JwtSettings:Issuer"],
			audience: Configuration["JwtSettings:Audience"],
			expires: DateTime.Now.AddMinutes(60),
			claims: myClaims,
			signingCredentials: cred);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	private static string RoleFactory(int roleNumber)
	{
		switch (roleNumber)
		{
			case 1:
				return "Convidado";
			case 2:
				return "Admin";
			default:
				throw new Exception();
		}
	}
}