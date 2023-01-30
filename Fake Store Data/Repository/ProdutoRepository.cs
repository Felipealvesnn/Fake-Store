using Fake_Store_Data.DataSet;
using Fake_Store_Domain.Interfaces;
using Fake_Store_Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fake_Store_Data.Repository
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly DbSet _context;

        public ProdutoRepository(DbSet context)
        {
            _context = context;
        }

        public void Adicionar(Product Product)
        {
           
            throw new NotImplementedException();
        }

        public void Atualizar(Product Product)
        {
            throw new NotImplementedException();
        }

        public Product RetornaProdutoPorId(int? id)
        {
            var client = new RestClient($"https://fakestoreapi.com/products/{id}");

            
            var request = new RestRequest("", Method.Get);
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("Accept", "application/json, text/plain, */*");
            var queryResult = client.Execute<Product>(request).Data;

            // var Model = JsonConvert.DeserializeObject<List<Product>>(queryResult.Content);

            return queryResult;
        }

        public void Remover(Product Product)
        {
            throw new NotImplementedException();
        }

        public async Task< IEnumerable<Product>> RetornaTodos(int? limite)
        {
    
             var   client = new RestClient($"https://fakestoreapi.com/products?limit={limite}");
            //var client = new RestClient($"https://fakestoreapi.com/products?limit=");

            var request =  new RestRequest("",Method.Get);
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("Accept", "application/json, text/plain, */*");
            var queryResult =  client.Execute<IEnumerable<Product>>(request).Data;
            

            return  queryResult;
        }
    }
}
