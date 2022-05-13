using System.Collections.Generic;
using WebSiteCore.Models;

namespace WebSiteCore.ViewModels
{
    public class AutoViewModel
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
        public List<PhotoViewModel> Photos { get; set; }
    }
}
