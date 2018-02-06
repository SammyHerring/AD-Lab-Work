using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APDRecapV1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 0
            decimal retail_price;
            decimal trade_price;
            int number_sold;
            decimal final_price;
            decimal profit;
            decimal final_trade;

            Console.WriteLine("Input Retail cost of item");
            while (!decimal .TryParse (Console.ReadLine (), out retail_price))
            { Console.WriteLine("Please enter a number"); }

            Console.WriteLine("Input Trade price of an item");
            while (!decimal.TryParse(Console.ReadLine(), out trade_price ))
            { Console.WriteLine("Please enter a number"); }

            Console.WriteLine("Input Number Required");
            while (!int.TryParse(Console.ReadLine(), out number_sold))
            { Console.WriteLine("Please enter a whole number"); }

            final_price = retail_price * number_sold;
            final_trade = trade_price * number_sold;
            profit = final_price - final_trade;


            Console.WriteLine("Final Price of Sale {0:c}", final_price);
            Console.WriteLine("Profit of sale {0:c}", profit);

            Console.ReadKey();




        }
    }
}
