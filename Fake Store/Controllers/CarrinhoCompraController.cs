using Fake_Store_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fake_Store.Controllers
{
    public class CarrinhoCompraController : Controller
    {
     
        private readonly IProductRepository _Product;

        public CarrinhoCompraController( IProductRepository Product)
        {
           
            _Product = Product;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        
        public IActionResult AdicionarAoCarrinho(int id)
        {
            var Productelecionado = _Product.RetornaProdutoPorId(id);
            


           


             return Json(new { success = "sucesso" });
           // return View("~/Views/Home/Index.cshtml");
        }
    }
}
