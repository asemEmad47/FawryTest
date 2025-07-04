using ConsoleApp1.InterFaces.IProductDir;

namespace ConsoleApp1.Models.ProductDir
{
    public class Product: IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
