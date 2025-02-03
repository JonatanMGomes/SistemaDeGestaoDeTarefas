using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Models;
using SistemaDeGestaoDeTarefas.Repositories.Interfaces;

namespace SistemaDeGestaoDeTarefas.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class TarefaController : ControllerBase
        {
            private readonly ITarefaRepository _repository;

            public TarefaController(ITarefaRepository repository)
            {
                _repository = repository;
            }

            [HttpPost("Criar")]
            public IActionResult Create(Tarefa tarefa)
            {
                _repository.Create(tarefa);
                return Ok();
            }

            [HttpGet("Buscar todos")]
            public IActionResult GetAll()
            {
                var tarefas = _repository.GetAll();
                return Ok(tarefas);
            }

            [HttpGet("Buscar por ID")]
            public IActionResult GetById(int id)
            {
                var tarefa = _repository.GetById(id);
                if (tarefa == null)
                    return NotFound();

                return Ok(tarefa);
            }

            [HttpPut("Atualizar")]
            public IActionResult Update(int id, Tarefa tarefa)
            {
                var tarefaAAtualizar = _repository.GetById(id);

                if (tarefaAAtualizar == null)
                    return NotFound();

                _repository.Update(tarefa);
                return Ok();
            }

            [HttpDelete("Deletar")]
            public IActionResult Delete(int id)
            {
                var tarefa = _repository.GetById(id);
                if (tarefa == null)
                {
                    return NotFound();
                }

                _repository.DeleteById(id);
                return Ok();
            }
        }
}
