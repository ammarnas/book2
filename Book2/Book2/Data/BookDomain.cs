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
                    Console.WriteLine("Login Successfully...");
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
            Console.WriteLine("- Enter 1 To Show Short Info Of Books");
            Console.WriteLine("- Enter 2 To Show All Info Of Book");
            Console.WriteLine("- Enter 3 To Delete Book");
            Console.WriteLine("- Enter 4 To Edit Book\n");
            Console.Write("- Enter Number To Excute It \n > ");

        }
        // Short Info
        public static void ShortInfo()
        {
            using (Book_ManagementEntities Context =new Book_ManagementEntities())
            {
                var Shortinfo = Context.Books
                                .Select(b => new { b.Id, b.Title }).ToList();
                foreach (var item in Shortinfo)
                {
                    Console.WriteLine("- "+item.Id +"    "+item.Title);
                }
            }
            Console.Write("- Enter Number To Excute It \n > ");
        }
        public static void BookInfo()
        {
            Console.Write("- Enter Id Of Book To get Information \n > ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (Book_ManagementEntities Context =new Book_ManagementEntities ())
            {
                var book = Context.Books.Where(b => b.Id == id).FirstOrDefault();

                Console.WriteLine($" id: {book.Id} Title: {book.Title} Price: {book.Price} Quantity: {book.Quantity}");
            }
            Console.Write("- Enter Number To Excute It \n > ");
        }
        public static void DeleteBook()
        {
            Console.Write("- Enter Id Of Book You Want To Delete It \n > ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (Book_ManagementEntities Context = new Book_ManagementEntities())
            {
                var book = Context.Books.Where(b => b.Id == id).FirstOrDefault();
                Console.WriteLine($"If You Sure You Want To Delete {book.Title} Book Press y or press n");
                string IsDelete=Console.ReadLine();
                if (IsDelete=="y")
                {
                    Context.Books.Remove(book);
                    Context.SaveChanges();
                }
                else
                    Console.WriteLine("Delete Has Been Cancelled");
            }
            Console.Write("- Enter Number To Excute It \n > ");
        }
        public static void UpdateBook()
        {
            Console.Write("- Enter Id Of Book \n > ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("- Enter New Titel Of Book \n > ");
            String Titel = Console.ReadLine();
            Console.Write("- Enter New Price Of Book \n > ");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("- Enter New Quantity Of Book \n > ");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            using (Book_ManagementEntities Context = new Book_ManagementEntities())
            {
                var book = Context.Books.Where(b => b.Id == id).FirstOrDefault();

                book.Title = Titel;
                book.Price = Price;
                book.Quantity = Quantity;
                Context.SaveChanges();
            }
            Console.Write("- Enter Number To Excute It \n > ");
        }
    }
}
