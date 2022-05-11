using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteCore.Models
{
    public class Order: Base
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int AutoID { get; set; }
        public Auto Auto { get; set; }
    }
}
