using Microsoft.AspNetCore.Mvc;
using ApiTarefas.ModelsViews;
using ApiTarefas.Dto;
using ApiTarefas.Models.Erros;
using ApiTarefas.Services.Interfaces;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : Controller
    {
        private ITarefaService _service;

        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var tarefas = _service.GetAll(page);
            return StatusCode(200, tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var tarefa = _service.GetById(id);
                return StatusCode(200, tarefa);
            }
            catch (TarefaErro erro)
            {
                return StatusCode(400, new ErrorView { Mensagem = erro.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = _service.Insert(tarefaDto);
                return StatusCode(201, tarefa);
            }
            catch (TarefaErro erro)
            {
                return StatusCode(400, new ErrorView { Mensagem = erro.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = _service.Update(id, tarefaDto);
                return StatusCode(200, tarefa);
            }
            catch (TarefaErro erro)
            {
                return StatusCode(400, new ErrorView { Mensagem = erro.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _service.Delete(id);
                return StatusCode(204);
            }
            catch (TarefaErro erro)
            {
                return StatusCode(400, new ErrorView { Mensagem = erro.Message });
            }
        }
    }
}
