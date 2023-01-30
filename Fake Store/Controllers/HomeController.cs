using Fake_Store.Models;
using Fake_Store_Domain.Interfaces;
using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;

namespace Fake_Store.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _Product;

        

        public HomeController(ILogger<HomeController> logger, IProductRepository lanches)
        {
            _logger = logger;
            _Product = lanches;
        }

        public async Task< IActionResult> Index()
        {
           var Model = await  _Product.RetornaTodos(5);

            
            return View( Model) ;
        }

        //public async Task<IActionResult> List(string filter, int pageindex = 1, string sort = "Nome")
        //{
        //    var resultado = await _Product.RetornaTodos();
        //    var querable = resultado.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        querable = querable.Where(p => p.description.Contains(filter)).AsQueryable();
                
        //    }

        //    var model = await PagingList.CreateAsync(querable, 3, pageindex, sort, "Nome");
        //    model.RouteValue = new RouteValueDictionary { { "filter", filter } };

        //    return View(model);
        //}

        public ViewResult Search(string searchString)
        {
            IEnumerable<Product> Product;

            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                var dsd = _Product.RetornaTodos(5);

                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //var dsd =  = _Product.RetornaTodos(searchString);

                //if (lanches.Any())
                //    categoriaAtual = "Lanches";
                //else
                //    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            //return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            //{
            //    lanches = lanches,
            //    CategoriaAtual = categoriaAtual
            //});
            return View();
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}