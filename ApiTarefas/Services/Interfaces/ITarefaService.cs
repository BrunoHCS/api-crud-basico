using ApiTarefas.Dto;
using ApiTarefas.Models;

namespace ApiTarefas.Services.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> GetAll(int page);
        Tarefa GetById(int id);
        Tarefa Insert(TarefaDto tarefaDto);
        Tarefa Update(int id, TarefaDto tarefaDto);
        void Delete(int id);
    }
}
