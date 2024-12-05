namespace GerenciadorDeTarefas.Model;

public class User
{
	public required int Type { get; set; }

	public required string UserName { get; set; }
	
	public required string Password { get; set; }
}