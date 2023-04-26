using SistemaDeTarefas.Enumns;

namespace SistemaDeTarefas.Entities.Models
{
    public class TarefaModel
    {
        public string Id { get; set; } 
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
