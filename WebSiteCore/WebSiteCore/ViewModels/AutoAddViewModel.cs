using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WebSiteCore.Models;
using System.Web;
namespace WebSiteCore.ViewModels
{
    public class AutoAddViewModel:Auto
    {
        public List<IFormFile> PhotoFiles { get; set; }
    }
}
