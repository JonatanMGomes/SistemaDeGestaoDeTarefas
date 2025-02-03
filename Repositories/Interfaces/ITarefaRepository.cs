using SistemaDeGestaoDeTarefas.Models;

namespace SistemaDeGestaoDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        public void Create(Tarefa tarefa);
        public List<Tarefa> GetAll(string status);
        public Tarefa GetById(int id);
        public void Update(Tarefa tarefa);
        public void DeleteById(int id);
    }
}
