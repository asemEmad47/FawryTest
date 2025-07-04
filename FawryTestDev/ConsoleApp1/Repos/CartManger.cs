
using ConsoleApp1.InterFaces;
using ConsoleApp1.InterFaces.IProductDir;
using ConsoleApp1.Models;
using ConsoleApp1.Models.ProductDir;

namespace ConsoleApp1.Repos
{
    public class CartManger : ICartManger
    {
        IProductManger _productManger;
        IProductFactory _productFactory;
        public CartManger(IProductManger productManger, IProductFactory productFactory)
        {
            _productManger = productManger;
            _productFactory = productFactory;
        }
        public string DisplayCart(Cart cart)
        {
            if (cart == null || cart.Products == null || !cart.Products.Any())
                return "Your cart is empty.";

            string result = "Your cart contains:\n";

            foreach (var product in cart.Products)
            {
                result += $"ID: {product.Id}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price}, Total: {product.Quantity * product.Price}\n";
            }

            result += $"Subtotal: {CaluclateSubTotal(cart)}\n";
            result += $"Shipping Fees: {CaluclateShippingFees(cart)}\n";
            result += $"Total Paid Amount: {CaluclatePaidAmount(cart)}\n";

            return result;
        }
        public string AddToCart(IProduct product, int quantity, User user)
        {
            Cart cart = user.Cart;
            if (_productManger.HasEnoughQuantity(product.Id, quantity))
            {
                if (cart != null)
                {
                    if ((user.Balance >= (double)(quantity*product.Price)))
                    {
                        user.Balance -= (double)(quantity * product.Price);
                        var addedProduct = _productFactory.CreateCopyWithQuantity(product, quantity);
                        addedProduct.Quantity = quantity; 
                        user.Cart.Products.Add(addedProduct);
                        _productManger.DecreaseQuantity(product.Id, quantity);
                        return ($"{product.Name} Added successfully to your cart");
                    }
                    else
                    {
                        return (" You don't have enough balance");

                    }

                }
                else
                {
                    return("Cart cannot be null.");
                }
            }
            else
            {
               return("Not enough quantity available to add to the cart.");
            }
        }

        public string RemoveFromCart(IProduct product, int quantity, User user)
        {
            Cart cart = user.Cart;
            if (cart != null)
            {
                if (cart!=null &&  cart.Products.Contains(product))
                {
                    if (product.Quantity >= quantity)
                    {
                        product.Quantity -= quantity;
                        if (product.Quantity == 0)
                        {
                            cart.Products.Remove(product);
                        }
                        user.Balance += (double)(quantity * product.Price);
                        _productManger.IncreaseQuantity(product.Id, quantity);
                    }
                    else
                    {
                        return("Not enough quantity in the cart to remove.");
                    }
                    return ($"{product.Name} Removed successfully from your cart");

                }
                else
                {
                    return("Product not found in the cart.");
                }

            }
            return ($"Your cart has no products!");

        }
        public double CaluclateSubTotal(Cart cart)
        {
            if (cart == null || cart.Products == null || !cart.Products.Any())
            {
                throw new InvalidOperationException("Cart is empty or null.");
            }
            double total =(double) cart.Products.Sum(p => p.Price*p.Quantity);
            return total;
        }

        public double CaluclateShippingFees(Cart cart)
        {
            if (cart.Products == null)
                return 0;

            return cart.Products
                .Where(p => p is IShippable)
                .Sum(p => p is IShippable shippable
                    ? shippable.ShippingCost * p.Quantity
                    : 0);
        }

        public double CaluclatePaidAmount(Cart cart)
        {
            return CaluclateSubTotal(cart) + CaluclateShippingFees(cart);
        }
        public double CalculateTotalWeight(Cart cart)
        {
            if (cart == null || cart.Products == null || !cart.Products.Any())
            {
                throw new InvalidOperationException("Cart is empty or null.");
            }
            return cart.Products
                .Where(p => p is IShippable)
                .Sum(p => p is IShippable shippable ? shippable.Weight * p.Quantity : 0);
        }
        public void ClearCart(Cart cart)
        {
            cart.Products.Clear();
        }
    }
}
