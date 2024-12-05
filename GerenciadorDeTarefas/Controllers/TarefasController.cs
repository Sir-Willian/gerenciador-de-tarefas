using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Model;
using GerenciadorDeTarefas.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers;

[ApiController()]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
	private readonly TarefaDbContext _context;

	public TarefasController(TarefaDbContext context) { _context = context; }

	[HttpGet("{id}")]
	[Authorize()]
	public ActionResult<Tarefa?> Get(int id)
	{
		Tarefa? tarefa = TarefaService.GetTarefa(id, _context);
		if(tarefa == null) { return NotFound(); }

		return tarefa;
	}

	[HttpGet()]
	[Authorize()]
	public ActionResult<List<Tarefa>> GetAll() => TarefaService.GetTarefas(_context);

	[HttpPost()]
	[Authorize(Roles = "Admin")]
	public ActionResult Post(Tarefa tarefa)
	{
		Tarefa? existingTarefa = TarefaService.GetTarefa(tarefa.Id, _context);
		if (existingTarefa != null) { return BadRequest(error: "Essa tarefa já existe."); }

        TarefaService.AddTarefa(tarefa, _context);

		return CreatedAtAction(nameof(Get), new { id = tarefa.Id}, tarefa);
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public ActionResult Delete(int id)
	{
		Tarefa? tarefa = TarefaService.GetTarefa(id, _context);
		if(tarefa == null) { return BadRequest(error: "Essa tarefa não existe."); }

		TarefaService.DeleteTarefa(tarefa, _context);

		return NoContent();
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Admin")]
	public ActionResult Put(int id, Tarefa upTarefa)
	{
		Tarefa? nonUpTarefa = TarefaService.GetTarefa(id, _context);
		if(nonUpTarefa == null) { return BadRequest(error: "Essa tarefa não existe."); }

		TarefaService.UpdateTarefa(nonUpTarefa, upTarefa, _context);

		return NoContent();
	}
}
