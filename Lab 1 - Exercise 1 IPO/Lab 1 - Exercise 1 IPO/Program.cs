//Project Name: Lab 1 - Exercise 1 IPO | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 31/1/2018 | 14:38
//Last Updated On:  31/1/2018 | 20:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1___Exercise_1_IPO
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal retailCost, tradeCost, profitValue;
            int productQuantity;

            retailCost = decimalParsedReturn("Enter retail cost: ");
            tradeCost = decimalParsedReturn("Enter trade cost: ");
            productQuantity = integerParsedReturn("Enter number of products required: ");

            if (productQuantity > 10)
            {
                tradeCost = (tradeCost * 0.9m);
            }

            profitValue = productQuantity * (retailCost - tradeCost); 

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
            } catch (FormatException)
            {
                Console.WriteLine("{0}: Bad Format", value);
                return integerParsedReturn(query);
            } catch (OverflowException)
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
