using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.Models;
using ApiTarefas.Models.Erros;
using ApiTarefas.Services.Interfaces;

namespace ApiTarefas.Services
{
    public class TarefaService : ITarefaService
    {
        private TarefasContext _db;
        public TarefaService(TarefasContext db)
        {
            _db = db;
        }

        public List<Tarefa> GetAll(int page) 
        {
            if (page < 1)
                page = 1; 

            int limit = 10;
            int offset = (page - 1) * limit;

            return _db.Tarefas.Skip(offset).Take(limit).ToList();
        }

        public Tarefa GetById(int id)
        {
            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null)
                throw new TarefaErro("Tarefa não encontrada");

            return tarefaDb;
        }

        public Tarefa Insert(TarefaDto tarefaDto)
        {
            if (string.IsNullOrEmpty(tarefaDto.Titulo))
                throw new TarefaErro("Titulo não pode ser vazio");

            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Concluida = tarefaDto.Concluida,
            };

            _db.Tarefas.Add(tarefa);
            _db.SaveChanges();

            return tarefa;
        }

        public Tarefa Update(int id, TarefaDto tarefaDto)
        {
            if (string.IsNullOrEmpty(tarefaDto.Titulo))
                throw new TarefaErro("Titulo não pode ser vazio");

            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null)
                throw new TarefaErro("Tarefa não encontrada");

            tarefaDb.Titulo = tarefaDto.Titulo;
            tarefaDb.Descricao = tarefaDto.Descricao;
            tarefaDb.Concluida = tarefaDto.Concluida;

            _db.Tarefas.Update(tarefaDb);
            _db.SaveChanges();
            return tarefaDb;
        }

        public void Delete(int id)
        {
            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null)
                throw new TarefaErro("Tarefa não encontrada");

            _db.Tarefas.Remove(tarefaDb);
            _db.SaveChanges();
        }
    }
}
