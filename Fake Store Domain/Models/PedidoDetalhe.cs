using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Domain.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }
        public int ProdutosId { get; set; }
        public virtual Produtos Produtos { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
