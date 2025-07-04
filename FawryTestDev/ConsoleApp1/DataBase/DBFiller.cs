using ConsoleApp1.Models;
using ConsoleApp1.Models.ProductDir;

namespace ConsoleApp1.DataBase
{
    public class DBFiller
    {
        public void FillUsers()
        {
            if (DB.Users.Count == 0)
            {
                DB.Users.Add(new User { Email = "asememad984@gmail.com", Password = "1234" , Balance = 4000});
                DB.Users.Add(new User { Email = "asememad332@gmail.com", Password = "1234", Balance = 10000 });
            }
        }

        public void FillProducts()
        {
            if (DB.Products.Count == 0)
            {
                DB.Products.Add(new Product { Id = 1, Name = "Product1", Price = 100, Quantity = 1000 });

                DB.Products.Add(new ShippableProduct { Id = 2, Name = "TV", Price = 200, Quantity = 300 , ShippingCost = 10 , Weight = 5 });

                DB.Products.Add(new ExpirableProduct { Id = 3, Name = "Biscuits", Price = 10 , Quantity = 400, ExpiryDate  = new DateTime(2025, 12, 31) });

                DB.Products.Add(new ExpirableShippableProduct { Id = 4, Name = "Cheese", Price = 20 , Quantity = 500, ExpiryDate = new DateTime(2025, 12, 31), ShippingCost = 10, Weight = 5 });
            }
        }

    }
}
