using ConsoleApp1.InterFaces.IProductDir;
using ConsoleApp1.Models;

namespace ConsoleApp1.DataBase
{
    public static class DB
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<IProduct> Products { get; set; } = new List<IProduct>();

    }
}
