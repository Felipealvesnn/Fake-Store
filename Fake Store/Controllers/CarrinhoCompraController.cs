using Fake_Store_Aplication;
using Microsoft.AspNetCore.Mvc;

namespace Fake_Store.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly CarrinhoCompra _carrrinhoCompra;

        public CarrinhoCompraController(CarrinhoCompra carrrinhoCompra)
        { 
            _carrrinhoCompra = carrrinhoCompra;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
