using Microsoft.AspNetCore.Mvc;

namespace WebAPITickets.Controllers
{
    public class TiquetesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
