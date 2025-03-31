using Microsoft.AspNetCore.Mvc;

namespace WebAPITickets.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
