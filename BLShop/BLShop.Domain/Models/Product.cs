﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLShop.Domain.Models
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public double Price { get; set; }

       public int SupplierId { get; set; }
       public Supplier Supplier { get; set; }
       public string PhotoUrl { get; set; }
    }
}
