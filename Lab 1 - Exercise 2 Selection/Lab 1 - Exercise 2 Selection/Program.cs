//Project Name: Lab 1 - Exercise 2 Selection | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 1/2/2018 | 00:23
//Last Updated On:  1/2/2018 | 20:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1___Exercise_2_Selection
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal retailCost = 0, tradeCost = 0, profitValue, vatValue = 0.2m;
            int productQuantity;
            string product;
            bool productSelected = false;
            var laptop = (retailCost: 499, tradeCost: 299);
            var desktop = (retailCost: 399, tradeCost: 289);
            var printer = (retailCost: 99, tradeCost: 65);

            Console.WriteLine("--Product Listing--");
            Console.WriteLine(" - (L)aptop");
            Console.WriteLine(" - (D)esktop");
            Console.WriteLine(" - (P)rinter");
            while (!productSelected)
            {
                Console.Write("Enter the required product: ");
                product = Console.ReadLine();

                switch (product.ToLower())
                {
                    case "l":
                        retailCost = laptop.retailCost;
                        tradeCost = laptop.tradeCost;
                        productSelected = true;
                        break;
                    case "d":
                        retailCost = desktop.retailCost;
                        tradeCost = desktop.tradeCost;
                        productSelected = true;
                        break;
                    case "p":
                        retailCost = printer.retailCost;
                        tradeCost = printer.tradeCost;
                        productSelected = true;
                        break;
                    default:
                        break;
                }
            }
            productQuantity = integerParsedReturn("Enter number of products required: ");

            if (productQuantity > 10)
            {
                tradeCost = (tradeCost * 0.9m);
            }

            profitValue = productQuantity * (retailCost - (tradeCost * (1 + vatValue)));

            Console.WriteLine("\nRetail Cost: {0}; Trade Cost: {1}; Product Quantity: {2}; Profit: {3};", retailCost, tradeCost, productQuantity, profitValue);
            Console.ReadLine();
        }

        static int integerParsedReturn(string query)
        {
            int value = 0;
            Console.Write(query);
            try
            {
                value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0}: Bad Format", value);
                return integerParsedReturn(query);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0}: Overflow", value);
                return integerParsedReturn(query);
            }
        }

        static decimal decimalParsedReturn(string query)
        {
            decimal value = 0;
            Console.Write(query);
            try
            {
                value = decimal.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0}: Bad Format", value);
                return decimalParsedReturn(query);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0}: Overflow", value);
                return decimalParsedReturn(query);
            }
        }
    }
}