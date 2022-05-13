namespace WebSiteCore.Models
{
    public class AutoName
    {   public int Id { get; set; } 
        public string Name { get; set; }
        public virtual AutoBrand AutoBrand { get; set; }
    }
}
