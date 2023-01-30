using Fake_Store_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Domain.Interfaces
{
    public interface IProductRepository
    {
       Task< IEnumerable<Product>> RetornaTodos(int? limite);
        Product RetornaProdutoPorId(int? id);
        void Adicionar(Product Product);
        void Atualizar(Product Product);
        void Remover(Product Product);
    }
}
