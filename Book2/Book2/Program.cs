using Book2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Project....\n");
            BookDomain.AddDefualtUser();

            BookDomain.Login();
            BookDomain.BookCount();
            BookDomain.UserControl();

            wordcontrol:
            Console.Write(" > ");
            int WordControl = Convert.ToInt32(Console.ReadLine());

            switch (WordControl)
            {
                case 1:
                    BookDomain.ShortInfo();
                    goto wordcontrol;
                    break;
                case 2:
                    BookDomain.BookInfo();
                    goto wordcontrol;
                    break;
                case 3:
                    BookDomain.DeleteBook();
                    goto wordcontrol;
                    break;
                case 4:
                    BookDomain.UpdateBook();
                    goto wordcontrol;
                    break;
                
            }
            Console.ReadLine();
        }
    }
}
