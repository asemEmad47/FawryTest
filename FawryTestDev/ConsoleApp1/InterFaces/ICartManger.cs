using ConsoleApp1.InterFaces.IProductDir;
using ConsoleApp1.Models;

namespace ConsoleApp1.InterFaces
{
    public interface ICartManger
    {
        public string AddToCart(IProduct product, int quantity ,  User user);
        public string RemoveFromCart(IProduct product , int quantity,User user);
        public void ClearCart(Cart cart);
        public double CaluclateSubTotal(Cart cart);
        public double CaluclateShippingFees(Cart cart);
        public double CaluclatePaidAmount(Cart cart);
        public double CalculateTotalWeight(Cart cart);
        public string DisplayCart(Cart cart);
    }
}
