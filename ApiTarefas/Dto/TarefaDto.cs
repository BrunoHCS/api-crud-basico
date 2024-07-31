using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.Dto
{
    public record TarefaDto
    {
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}
