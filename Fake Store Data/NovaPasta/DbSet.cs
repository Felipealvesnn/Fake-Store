using Fake_Store_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Data.NovaPasta
{
    public class DbSet :IdentityDbContext<IdentityUser>
    {
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItem { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
