﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLShop.Domain.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public List<Product> Products { get; set; }
    }
}
