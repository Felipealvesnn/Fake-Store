using Fake_Store_Domain.Interfaces;
using Fake_Store_Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fake_Store_Data.Repository
{
    public class ProdutoRepository : IProdutosRepository
    {
        
   
        public void Adicionar(Produtos produtos)
        {
           
            throw new NotImplementedException();
        }

        public void Atualizar(Produtos produtos)
        {
            throw new NotImplementedException();
        }

        public Produtos PegaLanchePorId(int? id)
        {
            throw new NotImplementedException();
        }

        public void Remover(Produtos produtos)
        {
            throw new NotImplementedException();
        }

        public async Task< IEnumerable<Produtos>> RetornaTodos()
        {
          
            var client = new RestClient("https://fakestoreapi.com/products");
            var request =  new RestRequest("",Method.Get);
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("Accept", "application/json, text/plain, */*");
            var queryResult =  client.Execute<IEnumerable<Produtos>>(request).Data;

           // var Model = JsonConvert.DeserializeObject<List<Produtos>>(queryResult.Content);

            return  queryResult;
        }
    }
}
