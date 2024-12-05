using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeTarefas.Model;

[Table("tarefas")]
public class Tarefa
{
	[Column("id")]
	[Key()]
	public int Id { get; set; }

	[Column("nome")]
	[Required(ErrorMessage = "O nome é obrigatório.")]
	[MinLength(2, ErrorMessage = "O mínimo de caracteres para o título é 2.")]
	[MaxLength(100, ErrorMessage = "O máximo de caracteres para o título é 100.")]
	public string? Nome { get; set; }

	[Column("descricao")]
	public string? Descricao { get; set; }

	[Column("status")]
	[Required( ErrorMessage = "O status é obrigatório.")]
	[AllowedValues(values: [ "Pendente", "Em Andamento", "Concluído" ], ErrorMessage = "Escolha um dos três status (Pendente, Em Andamento ou Concluído).")]
	public string? Status { get; set; }

	[Column("data_criacao")]
	public DateOnly DataCriacao { get; private set; } = DateOnly.FromDateTime(DateTime.Today);
}