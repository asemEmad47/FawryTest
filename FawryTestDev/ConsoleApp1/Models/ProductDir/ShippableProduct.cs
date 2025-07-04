using ConsoleApp1.InterFaces.IProductDir;

namespace ConsoleApp1.Models.ProductDir
{
    class ShippableProduct:IProduct , IShippable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double ShippingCost { get; set; }
        public double Weight { get; set; }

        public ShippableProduct(int id, string name, decimal price, int quantity, double shippingCost)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ShippingCost = shippingCost;
        }
        public ShippableProduct()
        {
        }
   
    }
}
