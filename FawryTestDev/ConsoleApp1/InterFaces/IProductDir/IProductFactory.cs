namespace ConsoleApp1.InterFaces.IProductDir
{
    public interface IProductFactory
    {
        IProduct CreateCopyWithQuantity(IProduct original, int quantity);
    }
}
