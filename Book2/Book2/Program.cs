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

            BookDomain.UserControl();

            int WordControl = Convert.ToInt32(Console.ReadLine());

            switch (WordControl)
            {
                case 1:
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    break;
                
            }
        }
    }
}
