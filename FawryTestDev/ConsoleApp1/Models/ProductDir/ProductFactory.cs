using ConsoleApp1.InterFaces.IProductDir;
using System;
namespace ConsoleApp1.Models.ProductDir
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateCopyWithQuantity(IProduct original, int quantity)
        {
            switch (original)
            {
                case ExpirableShippableProduct es:
                    return new ExpirableShippableProduct
                    {
                        Id = es.Id,
                        Name = es.Name,
                        Price = es.Price,
                        Quantity = quantity,
                        ExpiryDate = es.ExpiryDate,
                        ShippingCost = es.ShippingCost,
                        Weight = es.Weight
                    };

                case ExpirableProduct e:
                    return new ExpirableProduct
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Price = e.Price,
                        Quantity = quantity,
                        ExpiryDate = e.ExpiryDate
                    };

                case ShippableProduct s:
                    return new ShippableProduct
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Price = s.Price,
                        Quantity = quantity,
                        ShippingCost = s.ShippingCost,
                        Weight = s.Weight
                    };

                case Product p:
                    return new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = quantity
                    };

                default:
                    throw new ArgumentException("Unknown product type");
            }
        }
    }
}
