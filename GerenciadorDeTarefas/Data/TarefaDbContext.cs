using GerenciadorDeTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Data;

public class TarefaDbContext : DbContext
{
	public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options) { }

	public DbSet<Tarefa> Tarefas { get; set; }
}
