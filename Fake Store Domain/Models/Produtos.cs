using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fake_Store_Domain.Models
{
    public class Rating
    {
        public int id { get; set; }
        public double rate { get; set; }
        public int count { get; set; }
        public int ProductId { get; set; }
    }
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }
}
