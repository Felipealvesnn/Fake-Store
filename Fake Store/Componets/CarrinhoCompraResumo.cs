using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Fake_Store.Componets
{
    public class CarrinhoCompraResumo : ViewComponent
    {
     
        public IViewComponentResult Invoke()
        {

            var client = new RestClient($"https://fakestoreapi.com/carts/1");
            

            var request = new RestRequest("", Method.Get);
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("Accept", "application/json, text/plain, */*");
            var queryResult = client.Execute<CarrinhoCompraFakeStore>(request).Data;
            
         

            return View(queryResult);
        }

    }
}
