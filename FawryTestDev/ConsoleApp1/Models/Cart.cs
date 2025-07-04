using ConsoleApp1.InterFaces.IProductDir;


namespace ConsoleApp1.Models
{
    public class Cart
    {
        public List<IProduct>? Products { get; set; } = new List<IProduct>();
    }
}
