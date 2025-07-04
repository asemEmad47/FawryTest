using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp1.InterFaces.IProductDir
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
    }
}
