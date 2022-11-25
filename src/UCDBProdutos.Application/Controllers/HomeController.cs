using Microsoft.AspNetCore.Mvc;

namespace UCDBProdutos.Application.Controllers
{
    public class HomeController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }
    }
}
