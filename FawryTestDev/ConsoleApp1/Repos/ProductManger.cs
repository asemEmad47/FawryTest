using ConsoleApp1.InterFaces;
using ConsoleApp1.DataBase;
using ConsoleApp1.Models.ProductDir;
namespace ConsoleApp1.Repos
{
    public class ProductManger : IProductManger
    {
        public bool DecreaseQuantity(int productId, int quantity)
        {
            if(!HasEnoughQuantity(productId, quantity))
            {
                return false;
            }

            var product = DB.Products.FirstOrDefault(p => p.Id == productId);
            DB.Products.Remove(product);
            product.Quantity -= quantity;
            DB.Products.Add(product);

            return true;
        }

        public bool HasEnoughQuantity(int productId, int quantity)
        {
            return DB.Products.FirstOrDefault(p => p.Id == productId)?.Quantity >= quantity;
        }

        public bool IncreaseQuantity(int productId, int quantity)
        {
            var product = DB.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return false; 
            }

            DB.Products.Remove(product);
            product.Quantity += quantity;
            DB.Products.Add(product);
            return true;
        }
    }
}
