using Microsoft.AspNetCore.Mvc;
using ApiTarefas.ModelsViews;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public HomeView Index()
        {
            return new HomeView 
            {
                Mensagens = "Bem vindo a API de Tarefas",
                Documentacao = "/swagger"
            };
        }
    }
}
