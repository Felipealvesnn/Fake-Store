using Fake_Store_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Domain.Interfaces
{
    public interface IProdutosRepository
    {
       Task< IEnumerable<Produtos>> RetornaTodos();
        Produtos PegaLanchePorId(int? id);
        void Adicionar(Produtos produtos);
        void Atualizar(Produtos produtos);
        void Remover(Produtos produtos);
    }
}
