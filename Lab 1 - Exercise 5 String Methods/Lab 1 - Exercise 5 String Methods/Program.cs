﻿//Project Name: Lab 1 - Exercise 5 String Methods | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 31/1/2018 | 18:25
//Last Updated On:  1/2/2018 | 22:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1___Exercise_5_String_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal retailCost = 0, tradeCost = 0, profitValue, vatValue = 0.2m, discountPercent = 0.0m, totalRetailCost = 0.0m, totalTradeCost = 0.0m, totalProfitValue = 0.0m;
            int productQuantity, discountQuantity = 0, iterationNo = 0, totalProductQuantity = 0;
            string product, mode = "0";
            bool productSelected = false, systemRunning = false, modeSelected = false;
            var laptop = (retailCost: 499, tradeCost: 299, discountQuantity: 5, discountPercent: 0.1m);
            var desktop = (retailCost: 399, tradeCost: 289, discountQuantity: 7, discountPercent: 0.12m);
            var printer = (retailCost: 99, tradeCost: 65, discountQuantity: 10, discountPercent: 0.05m);

            Console.WriteLine("Retail POS System");

            systemModeSelection(ref modeSelected, ref mode, ref systemRunning);

            while (systemRunning)
            {
                iterationNo += 1;

                Console.WriteLine("\n--Product Listing--");
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
                            discountQuantity = laptop.discountQuantity;
                            discountPercent = laptop.discountPercent;
                            productSelected = true;
                            break;
                        case "d":
                            retailCost = desktop.retailCost;
                            tradeCost = desktop.tradeCost;
                            discountQuantity = desktop.discountQuantity;
                            discountPercent = desktop.discountPercent;
                            productSelected = true;
                            break;
                        case "p":
                            retailCost = printer.retailCost;
                            tradeCost = printer.tradeCost;
                            discountQuantity = printer.discountQuantity;
                            discountPercent = printer.discountPercent;
                            productSelected = true;
                            break;
                        default:
                            productSelected = false;
                            break;
                    }
                }
                productQuantity = integerParsedReturn("Enter number of products required: ");

                if (boolQuery("Generate Invoice"))
                {
                    Console.WriteLine("Generating.. lol");
                }

                if (productQuantity > discountQuantity)
                {
                    tradeCost = (tradeCost * (1.0m - discountPercent));
                }

                profitValue = productQuantity * (retailCost - (tradeCost * (1 + vatValue)));

                totalRetailCost += retailCost;
                totalTradeCost += tradeCost;
                totalProductQuantity += productQuantity;
                totalProfitValue += profitValue;

                Console.Write("\nData Set: {0}", iterationNo);
                Console.WriteLine("\nRetail Cost: {0}; Trade Cost: {1}; Product Quantity: {2}; Profit: {3};", retailCost, tradeCost, productQuantity, profitValue);
                Console.ReadLine();

                systemModeCleanup(ref modeSelected, ref productSelected, ref systemRunning);
                systemModeSelection(ref modeSelected, ref mode, ref systemRunning);
            }

            Console.WriteLine("\nTotal No of Data Sets: {0}", iterationNo);
            Console.WriteLine("\nTotal Retail Cost: {0}; Total Trade Cost: {1}; Total Product Quantity: {2}; Total Profit: {3};", totalRetailCost, totalTradeCost, totalProductQuantity, totalProfitValue);
            Console.WriteLine("\n--System End--");
            Console.ReadLine();

        }

        static void systemModeCleanup(ref bool modeSelected, ref bool productSelected, ref bool systemRunning)
        {
            productSelected = false;
            systemRunning = false;
            modeSelected = false;
        }

        static void systemModeSelection(ref bool modeSelected, ref string mode, ref bool systemRunning)
        {
            while (!modeSelected)
            {
                Console.Write("\nEnter (S)ale or (E)nd of Day: ");
                mode = Console.ReadLine();

                switch (mode.ToLower())
                {
                    case "s":
                        modeSelected = true;
                        systemRunning = true;
                        break;
                    case "e":
                        modeSelected = true;
                        systemRunning = false;
                        break;
                    default:
                        modeSelected = false;
                        systemRunning = false;
                        break;
                }
            }
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

        static bool boolQuery(string query)
        {
            Console.Write("{0 (y/n)?", query);
            string value = Console.ReadLine().ToLower();
            if (value == "yes")
            {
                return true;
            } else if (value == "no")
            {
                return false;
            }
            else
            {
                return boolQuery(query);
            }
        }
    }
}