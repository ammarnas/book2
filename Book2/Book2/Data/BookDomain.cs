using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book2.Data
{
    class BookDomain
    {
        public static void AddDefualtUser()
        {
            using (Book_ManagementEntities Context = new Book_ManagementEntities())
            {
                int IsAddUser = Context.Users.Count();
                if (IsAddUser == 0)
                {
                    string Contents = File.ReadAllText(@"C:\Users\Ammar\source\repos\book2\Book2\Book2\Data\DefualtUser.json");
                    var DefualtUser = JsonSerializer.Deserialize<List<User>>(Contents);
                    Context.Users.AddRange(DefualtUser);
                    Context.SaveChanges();
                }
            }
        }

        // Login
        public static void Login()
        {
            try
            {
            login:
                Console.Write("Enter Username : ");
                string Username = Console.ReadLine();

                Console.Write("Enter Password : ");
                string Password = Console.ReadLine();

                using (Book_ManagementEntities Context = new Book_ManagementEntities())
                {
                    var user = Context.Users.Where(u => u.Username == Username && u.Password == Password).ToList();
                    if (user.Count == 0)
                    {
                        Console.WriteLine("Username or Password uncorrect");
                        Console.WriteLine("Try Again");
                        goto login;
                    }
                    Console.WriteLine("Login Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        // Count of book
        public static void BookCount()
        {
            using (Book_ManagementEntities Context = new Book_ManagementEntities())
            {
                var Count = Context.Books.Select(u => u.Title).Distinct().Count();
                Console.WriteLine($"you have {Count} Books in store\n");
            }
        }
        // User Control
        public static void UserControl()
        {

            Console.WriteLine("- Enter 1 To Show Info Of Books");
            Console.WriteLine("- Enter 2 To Show All Info Of Books");
            Console.WriteLine("- Enter 3 To Delete Book");
            Console.WriteLine("- Enter 4 To Edit Book");
        }
        // 
    }
}
