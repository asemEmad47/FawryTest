using ConsoleApp1.DataBase;
using ConsoleApp1.InterFaces.IProductDir;
using ConsoleApp1.Models;
using ConsoleApp1.Models.ProductDir;
using ConsoleApp1.Repos;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DBFiller DBFiller = new DBFiller();
            DBFiller.FillUsers();
            DBFiller.FillProducts();

            Console.WriteLine("Database filled with initial data.");
            User currentUser = DB.Users[0];
            currentUser.Cart = new Cart();

            ProductManger productManger = new ProductManger();
            BaseRepo<IProduct> productRepo = new BaseRepo<IProduct>(DB.Products);
            ProductFactory productFactory = new ProductFactory();

            CartManger cartManager = new CartManger(productManger , productFactory);

            CheckOutManger checkoutManager = new CheckOutManger(cartManager);
            Console.WriteLine("Welcome to our app!");

            while (true)
            {
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. Remove Product from Cart");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        productRepo.GetAll().ForEach(product =>
                            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}"));
                        break;

                    case "2":
                        Console.Write("Enter Product ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int addId))
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }

                        var productToAdd = productRepo.GetById(addId);
                        if (productToAdd == null)
                        {
                            Console.WriteLine("Product not found.");
                            break;
                        }

                        Console.Write("Enter quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int addQuantity))
                        {
                            Console.WriteLine("Invalid quantity.");
                            break;
                        }

                        Console.WriteLine(cartManager.AddToCart(productToAdd, addQuantity, currentUser));
                        Console.WriteLine("Your balance now is " + currentUser.Balance);
                        break;

                    case "3":
                        Console.Write("Enter Product ID to remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }

                        var productToRemove = currentUser.Cart.Products.FirstOrDefault(p => p.Id == removeId);
                        if (productToRemove == null)
                        {
                            Console.WriteLine("Product not found in cart.");
                            break;
                        }

                        Console.Write("Enter quantity to remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int removeQuantity))
                        {
                            Console.WriteLine("Invalid quantity.");
                            break;
                        }

                        Console.WriteLine(cartManager.RemoveFromCart(productToRemove, removeQuantity, currentUser));
                        Console.WriteLine("Your balance now is " + currentUser.Balance);
                        break;

                    case "4":
                        Console.WriteLine(cartManager.DisplayCart(currentUser.Cart));
                        break;

                    case "5":
                        checkoutManager.CheckOut(currentUser.Cart);
                        Console.WriteLine("Your balance now is " + currentUser.Balance);
                        break;

                    case "6":
                        Console.WriteLine("Thank you! Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

    }
}
