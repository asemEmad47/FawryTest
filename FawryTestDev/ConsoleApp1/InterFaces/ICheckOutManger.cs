using ConsoleApp1.Models;

namespace ConsoleApp1.InterFaces
{
    interface ICheckOutManger
    {
        void CheckOut(Cart cart);
        void PrintReceipt(Cart cart);

    }
}
