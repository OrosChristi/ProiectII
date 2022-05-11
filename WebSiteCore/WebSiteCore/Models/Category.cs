﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebSiteCore.Models
{
    public class Category: Base
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Auto> Autos { get; set; }

    }
}
