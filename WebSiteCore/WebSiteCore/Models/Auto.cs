using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteCore.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public string Power { get; set; }
        public decimal EngineCapacity { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
