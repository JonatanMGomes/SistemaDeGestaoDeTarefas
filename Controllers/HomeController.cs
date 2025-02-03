using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Models;
using SistemaDeGestaoDeTarefas.Repositories.Interfaces;

namespace SistemaDeGestaoDeTarefas.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;

        public HomeController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public IActionResult Index()
        {
            var tarefas = _tarefaRepository.GetAll();
            return View(tarefas);
        }

        public IActionResult Details(int id)
        {
            var tarefa = _tarefaRepository.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Create(tarefa);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefaRepository.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Update(tarefa);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefaRepository.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tarefaRepository.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
