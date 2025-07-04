namespace ConsoleApp1.InterFaces
{
    public interface IProductManger
    {
        public bool HasEnoughQuantity(int productId, int quantity);
        public bool DecreaseQuantity(int productId, int quantity);
        public bool IncreaseQuantity(int productId, int quantity);
    }
}
