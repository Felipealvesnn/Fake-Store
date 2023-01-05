using Fake_Store.Models;
using Fake_Store_Aplication;
using Microsoft.AspNetCore.Mvc;

namespace Fake_Store.Componets
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrrinhoCompra;
        public CarrinhoCompraResumo(CarrinhoCompra carrrinhoCompra)
        {
            _carrrinhoCompra = carrrinhoCompra;
        }
        public IViewComponentResult Invoke()
        {
            var itens = _carrrinhoCompra.GetCarrinhoCompraItens();

            //var itens = new List<CarrinhoCompraItem>() {
            //new CarrinhoCompraItem(),
            //new CarrinhoCompraItem()

            //};

            _carrrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarinhoCompraVM
            {
                CarrinhoCompra = _carrrinhoCompra,
                CarrinhoCompraTotal = _carrrinhoCompra.GetCarrinhoCompraTotal(),
            };

            return View( carrinhoCompraVM);
        }

    }
}
