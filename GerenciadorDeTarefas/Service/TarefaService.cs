using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Model;

namespace GerenciadorDeTarefas.Service;

public static class TarefaService
{
	static TarefaService() { }

	public static Tarefa? GetTarefa(int id, TarefaDbContext _context) => _context.Tarefas.Find(id);

	public static List<Tarefa> GetTarefas(TarefaDbContext _context) => _context.Tarefas.ToList();

	public static void AddTarefa(Tarefa tarefa, TarefaDbContext _context)
	{
		_context.Tarefas.Add(tarefa);
		_context.SaveChanges();
	}

	public static void DeleteTarefa(Tarefa tarefa, TarefaDbContext _context)
	{
		_context.Tarefas.Remove(tarefa);
		_context.SaveChanges();
	}

	public static void UpdateTarefa(Tarefa nonUpTarefa, Tarefa upTarefa, TarefaDbContext _context)
	{
		nonUpTarefa.Nome = upTarefa.Nome ?? nonUpTarefa.Nome;
		nonUpTarefa.Descricao = upTarefa.Descricao ?? nonUpTarefa.Descricao;
		nonUpTarefa.Status = upTarefa.Status ?? nonUpTarefa.Status;
		_context.SaveChanges();
	}
}
