using Fake_Store_Data.DataSet;
using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fake_Store_Aplication
{
    public class CarrinhoCompra
    {

        private readonly DbSet _context;

        public CarrinhoCompra(DbSet context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<DbSet>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        private bool CarrinhoCompraItemExiste(int produtoid) => _context.CarrinhoCompraItem.Any(
                     s => s.Produtosid == produtoid &&
                     s.CarrinhoCompraId == CarrinhoCompraId);

        public void AdicionarAoCarrinho(Produtos produtos)
        {
            CarrinhoCompraItem carrinhoCompraItem = null;

            if (!CarrinhoCompraItemExiste(produtos.id))
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produtosid = produtos.id,

                    Quantidade = 1
                };

                try
                {

                    _context.CarrinhoCompraItem.Add(carrinhoCompraItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else

            {
                carrinhoCompraItem = _context.CarrinhoCompraItem.FirstOrDefault(
                     s => s.Produtosid == produtos.id &&
                     s.CarrinhoCompraId == CarrinhoCompraId);
                carrinhoCompraItem.Quantidade++;
                _context.Entry(carrinhoCompraItem).State = EntityState.Modified;
            }
            _context.SaveChanges();



            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        public int RemoverDoCarrinho(Produtos lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(
                   s => s.Produtosid == lanche.id &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItem.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems =
                       _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                           .Include(s => s.Produtos)
                           .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItem
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItem.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produtos.price * c.Quantidade).Sum();
            return (decimal)total;
        }

    }
}