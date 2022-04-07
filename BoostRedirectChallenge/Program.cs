using System;
using System.Text;

namespace BoostRedirectChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to enter your own data (A) or use the default data? (B)");
            string input = "";
            List<string> urls = new List<string>();

            while (true)
            {
                input = Console.ReadLine()!;
                if (input != "A" && input != "B")
                {
                    Console.WriteLine("Invalid Input, please input A or B");
                }
                else
                {
                    break;
                }

            }

            if (input == "A")
            {
                Console.WriteLine("Type one string at a time, not doing error handling on this one :)");
                Console.WriteLine("Type 'done' when you're done");

                input = Console.ReadLine();
                while (input != "done")
                {
                    urls.Add(input);
                    input = Console.ReadLine();
                }
            }
            else
            {
                urls = new List<string> {
                    "/home",
                    "/our-ceo.html -> /about-us.html",
                    "/about-us.html -> /about",
                    "/product-1.html -> /seo"
                };
            }

            Router myRouter = new Router();

            var myList = myRouter.Process(urls);

            Console.WriteLine("\n The results: \n");
            foreach (var entry in myList)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("\n");
        }
    }
}