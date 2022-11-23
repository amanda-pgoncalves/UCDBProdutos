using Microsoft.AspNetCore.Mvc;

namespace UCDBProdutos.Application.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
