﻿using ConsoleApp1.InterFaces.IProductDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp1.Models.ProductDir
{
    public class ExpirableProduct : IExpirable, IProduct
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
