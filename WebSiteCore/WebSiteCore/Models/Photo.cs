using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteCore.Models
{
    public class Photo: Base
    {
        public string UrlPath { get; set; }
        public int AutoId { get; set; }
        public virtual Auto Auto { get; set; }
        
    }
}
