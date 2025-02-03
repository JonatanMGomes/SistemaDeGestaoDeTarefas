using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoDeTarefas.Models;

namespace SistemaDeGestaoDeTarefas.Data
{
    public class SGTContext : DbContext
    {
        public SGTContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
