using Fake_Store.Models;
using Fake_Store_Domain.Interfaces;
using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;

namespace Fake_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutos _Produtos;

        

        public HomeController(ILogger<HomeController> logger, IProdutos lanches)
        {
            _logger = logger;
            _Produtos = lanches;
        }

        public async Task< IActionResult> Index()
        {
           var Model = await  _Produtos.RetornaTodos();

            return View( Model.Take(5)) ;
        }

    //    public async Task<IActionResult> List(string filter, int pageindex = 1, string sort = "Nome")
        //{
        //    var resultado = _Produtos.RetornaTodos();

        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        resultado = resultado.Where(p => p.description.Contains(filter));
        //    }

        //    var model = await PagingList.CreateAsync(resultado, 3, pageindex, sort, "Nome");
        //    model.RouteValue = new RouteValueDictionary { { "filter", filter } };

        //    return View(model);
     //   }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Produtos> Produtos;

            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                var dsd = _Produtos.RetornaTodos();

                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //var dsd =  = _Produtos.RetornaTodos(searchString);

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