using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoDeTarefas.Data;
using SistemaDeGestaoDeTarefas.Models;
using SistemaDeGestaoDeTarefas.Repositories.Interfaces;

namespace SistemaDeGestaoDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        protected readonly SGTContext _context;
        protected readonly DbSet<Tarefa> _dbSet;

        public TarefaRepository(SGTContext context, DbSet<Tarefa> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public void Create(Tarefa tarefa)
        {
            _dbSet.Add(tarefa);
            _context.SaveChanges();
        }
        public List<Tarefa> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public Tarefa GetById(int id)
        {
            return _dbSet.AsNoTracking().First(x => x.ID == id);
        }
        public void Update(Tarefa tarefa)
        {
            var tarefaAAtualizar = _dbSet.Find(tarefa.ID);
            if (tarefaAAtualizar != null)
            {
                tarefaAAtualizar.Titulo = tarefa.Titulo;
                tarefaAAtualizar.Descricao = tarefa.Descricao;
                tarefaAAtualizar.Status = tarefa.Status;

                _dbSet.Update(tarefaAAtualizar);
            }
        }
        public void DeleteById(int id)
        {
            var tarefaARemover = _dbSet.Find(id);
            _dbSet.Remove(tarefaARemover);
            _context.SaveChanges();
        }
    }
}
