namespace SistemaDeGestaoDeTarefas.Models
{
    public class Tarefa
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
