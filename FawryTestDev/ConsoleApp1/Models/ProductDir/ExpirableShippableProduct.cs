using ConsoleApp1.InterFaces.IProductDir;

namespace ConsoleApp1.Models.ProductDir
{
    class ExpirableShippableProduct : IShippable , IExpirable , IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double ShippingCost { get; set; }
        public double Weight { get; set; }

        public DateTime ExpiryDate { get; set; }

        public ExpirableShippableProduct(int id, string name, decimal price, int quantity, double shippingCost, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ShippingCost = shippingCost;
            ExpiryDate = expirationDate;
        }
        public ExpirableShippableProduct()
        {
        }
    }
}
