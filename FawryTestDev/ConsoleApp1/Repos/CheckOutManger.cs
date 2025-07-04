using ConsoleApp1.InterFaces;
using ConsoleApp1.InterFaces.IProductDir;
using ConsoleApp1.Models;
namespace ConsoleApp1.Repos
{
    public class CheckOutManger : ICheckOutManger
    {
        private readonly ICartManger _cartManger;
        public CheckOutManger(ICartManger cartManger)
        {
            _cartManger = cartManger;
        }
        public void PrintReceipt(Cart cart)
        {
            if (cart == null || cart.Products == null || !cart.Products.Any())
            {
                throw new InvalidOperationException("Cart is empty or null.");
            }

            Console.WriteLine("** Shipment notice **");

            cart.Products.ForEach(product =>
            {
                if (product is IShippable shippable)
                {
                    Console.WriteLine($"{product.Quantity}X {product.Name} : {shippable.Weight*product.Quantity}g ");
                }
            });
            Console.WriteLine($"Total weight : {_cartManger.CalculateTotalWeight(cart)}g ");

            Console.WriteLine($"\n ** Checkout receipt **");
            cart.Products.ForEach(product =>
            {
                Console.WriteLine($"{product.Quantity}X {product.Name} : {product.Price * product.Quantity}g ");
            });

            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Subtotal {_cartManger.CaluclateSubTotal(cart)}");
            Console.WriteLine($"Shipping {_cartManger.CaluclateShippingFees(cart)}");
            Console.WriteLine($"Amount {_cartManger.CaluclatePaidAmount(cart)}");


        }

        public void CheckOut(Cart cart)
        {
            PrintReceipt(cart);
            _cartManger.ClearCart(cart);
        }
    }
}
