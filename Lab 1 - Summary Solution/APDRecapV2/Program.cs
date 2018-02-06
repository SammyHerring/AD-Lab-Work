using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APDRecapV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 2
            decimal retail_price, final_retail_price;
            decimal trade_price, pre_VAT_trade_price;
            int number_sold;
            decimal final_price;
            decimal profit;
            decimal final_trade;
            const decimal VAT = 20m;

            int item_choice;

            //Task 2
            Console.WriteLine("Which item do you want to buy?");
            Console.WriteLine("1. Laptop\n2. Desktop\n3. Printer");
            while (!int.TryParse(Console.ReadLine(), out item_choice)
                || (item_choice < 1 || item_choice > 3))

                Console.WriteLine("Input Number Required");
            while (!int.TryParse(Console.ReadLine(), out number_sold))
            { Console.WriteLine("Please enter a whole number"); }

            // more of Task 2
            switch (item_choice)
            {
                case 1:
                    retail_price = 499;
                    pre_VAT_trade_price = 299;
                    break;
                case 2:
                    retail_price = 399;
                    pre_VAT_trade_price = 289;
                    break;
                case 3:
                    retail_price = 99;
                    pre_VAT_trade_price = 65;
                    break;
                default:
                    retail_price = 0;
                    pre_VAT_trade_price = 0;
                    break;
            }
            trade_price = pre_VAT_trade_price * (1 + (VAT / 100));

            if (number_sold > 10)
            {
                final_retail_price = Math.Round(retail_price * 90 / 100, 2);
            }
            else
            {
                final_retail_price = retail_price;
            }

            final_price = final_retail_price * number_sold;
            final_trade = trade_price * number_sold;
            profit = final_price - final_trade;


            Console.WriteLine("Final Price of Sale {0:c}", final_price);
            Console.WriteLine("Profit of sale {0:c}", profit);

            Console.ReadKey();
        }
    }
}
