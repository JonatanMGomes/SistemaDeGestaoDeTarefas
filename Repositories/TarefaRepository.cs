using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoDeTarefas.Data;
using SistemaDeGestaoDeTarefas.Models;
using SistemaDeGestaoDeTarefas.Repositories.Interfaces;

namespace SistemaDeGestaoDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        protected readonly SGTContext _context;

        public TarefaRepository(SGTContext context)
        {
            _context = context;
        }
        public void Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }
        public List<Tarefa> GetAll(string status)
        {
            if (status is not null)
                return _context.Tarefas.AsNoTracking().Where(x => x.Status == status).ToList();
            else
                return _context.Tarefas.AsNoTracking().ToList();
        }
        public Tarefa GetById(int id)
        {
            return _context.Tarefas.AsNoTracking().First(x => x.ID == id);
        }
        public void Update(Tarefa tarefa)
        {
            var tarefaAAtualizar = _context.Tarefas.Find(tarefa.ID);
            if (tarefaAAtualizar != null)
            {
                tarefaAAtualizar.Titulo = tarefa.Titulo;
                tarefaAAtualizar.Descricao = tarefa.Descricao;
                tarefaAAtualizar.Status = tarefa.Status;

                _context.Tarefas.Update(tarefaAAtualizar);
                _context.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            var tarefaARemover = _context.Tarefas.Find(id);
            _context.Tarefas.Remove(tarefaARemover);
            _context.SaveChanges();
        }
    }
}
