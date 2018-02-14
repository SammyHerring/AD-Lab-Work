using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APDRecapV6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Testing
            //Black Box Testing
            //Equivalence Partitions --> when valid is 1-10 --> P1: 0 (Boundary Check) / P2: 1-10 / P3: 11-99 (Boundary Check) / P4: 100
            //-1-->0 // 1,2,3 // 4-->1000 // int vs char
            */
            string[] items = { "Laptop", "Desktop", "Printer" };
            decimal[] retail_prices = { 499m, 399m, 99m };
            decimal[] trade_prices = { 299m, 289m, 65m };
            int[] discount_quantities = { 5, 7, 10 };
            int[] discount_values = { 10, 12, 5 };
            int[] quantity_sold = new int[3];
            decimal[] profits = new decimal[3];
            string process_choice;

            int item_choice;
            decimal retail_price, final_retail_price;
            decimal trade_price, pre_VAT_trade_price;
            int number_sold;
            decimal final_price;
            decimal profit;
            decimal final_trade;
            const decimal VAT = 20m;
            decimal total_sales = 0.0m;
            decimal total_profit = 0m;

            Console.WriteLine("What do you want to do:");
            Console.WriteLine("S: Sale");
            Console.WriteLine("E: End of Day");

            process_choice = Console.ReadLine();

            while (process_choice.ToUpper() == "S")
            {
                string full_name;
                string title;
                string surname;

                Console.WriteLine("Please enter your title, forenames and Surname");
                full_name = Console.ReadLine();
                title = full_name.Substring(0, full_name.IndexOf(" ")).ToUpper();
                surname = full_name.Substring(full_name.LastIndexOf(" ") + 1).ToUpper();


                Console.WriteLine("Which item do you want to buy?");
                for (int disp_loop = 0; disp_loop < 3; disp_loop++)
                {
                    Console.WriteLine("{0}.\t{1}", disp_loop + 1, items[disp_loop]);
                }
                while (!int.TryParse(Console.ReadLine(), out item_choice)
                    || (item_choice < 1 || item_choice > 3))
                { Console.WriteLine("Please enter a number 1 to 3"); }

                item_choice--;

                Console.WriteLine("Input Number Required");
                while (!int.TryParse(Console.ReadLine(), out number_sold))
                { Console.WriteLine("Please enter a whole number"); }

                // more of Task 2
                retail_price = retail_prices[item_choice];
                pre_VAT_trade_price = trade_prices[item_choice];
                trade_price = pre_VAT_trade_price * (1 + (VAT / 100));

                if (number_sold > discount_quantities[item_choice])
                {
                    final_retail_price = Math.Round(retail_price * (100 - discount_values[item_choice]) / 100, 2);
                }
                else
                {
                    final_retail_price = retail_price;
                }

                final_price = final_retail_price * number_sold;
                final_trade = trade_price * number_sold;
                profit = final_price - final_trade;

                total_sales += final_price;
                total_profit += profit;
                profits[item_choice] += profit;
                quantity_sold[item_choice] += number_sold;

                Console.WriteLine();
                Console.WriteLine("Invoice to : {0} {1}", title, surname);
                Console.WriteLine("Purchase of");
                Console.WriteLine("{0} {1} @ {2:c} :\t{3:c}", number_sold, items[item_choice], retail_price, retail_price * number_sold);
                if (final_retail_price != retail_price)
                {
                    Console.WriteLine("Discount of {0}% : \t{1:c}", discount_values[item_choice], retail_price * number_sold - final_price);
                    Console.WriteLine("Final Total: \t\t{0:C}", final_price);
                }
                Console.WriteLine();



                Console.WriteLine("What do you want to do:");
                Console.WriteLine("S: Sale");
                Console.WriteLine("E: End of Day");

                process_choice = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Total Sales: {0}", total_sales);
            Console.WriteLine("Total Profit: {0}", total_profit);
            Console.WriteLine("Item\t\tNumber Sold\tProfit");
            for (int item_loop = 0; item_loop < 3; item_loop++)
            {
                Console.WriteLine("{0}. {1}\t{2}\t\t{3:C}", item_loop + 1, items[item_loop], quantity_sold[item_loop], profits[item_loop]);
            }
            Console.ReadKey();

        }
    }
}
