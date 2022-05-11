﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int UserID { get; set; }
        public int AutoID { get; set; }
        public virtual User User { get; set; }
        public virtual Auto Auto { get; set; }
    }
}