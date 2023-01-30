using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Domain.Models
{
    public class CarrinhoCompraFakeStore
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public List<Product> products { get; set; }
        public int __v { get; set; }
    }
}
