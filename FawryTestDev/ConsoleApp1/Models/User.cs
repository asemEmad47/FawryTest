namespace ConsoleApp1.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public double Balance { get; set; }
        public Cart Cart { get; set; } = new Cart();
    }
}
