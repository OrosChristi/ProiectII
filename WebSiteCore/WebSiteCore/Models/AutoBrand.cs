using System.Collections.Generic;

namespace WebSiteCore.Models
{
    public class AutoBrand
    {   public int  Id { get; set; }
        public string Name { get; set; }
        public List<AutoName> AutoNames { get; set; }
    }
}
