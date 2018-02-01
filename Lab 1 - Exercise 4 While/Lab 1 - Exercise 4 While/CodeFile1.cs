//Project Name: Lab 1 - Exercise 4 While | File Name: CodeFile1.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 1/2/2018 | 18:52
//Last Updated On:  1/2/2018 | 18:55
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
            decimal retailCost = 0, tradeCost = 0, profitValue, vatValue = 0.2m, discountPercent = 0.0m, totalRetailCost = 0.0m, totalTradeCost = 0.0m, totalProfitValue = 0.0m;
            int productQuantity, discountQuantity = 0, iterationNo = 0, totalProductQuantity = 0;
            string product, mode = "0";
            bool productSelected = false, systemRunning = false, modeSelected = false;
            var laptop = (retailCost: 499, tradeCost: 299, discountQuantity: 5, discountPercent: 0.1m);
            var desktop = (retailCost: 399, tradeCost: 289, discountQuantity: 7, discountPercent: 0.12m);
            var printer = (retailCost: 99, tradeCost: 65, discountQuantity: 10, discountPercent: 0.05m);

            Console.WriteLine("Retail POS System");

            systemModeSelector(ref modeSelected, ref systemRunning, ref mode, ref iterationNo, ref totalRetailCost, ref totalTradeCost, ref totalProductQuantity, ref totalProfitValue);

            while (systemRunning)
            {
                if (!modeSelected)
                {
                    systemModeSelector(ref modeSelected, ref systemRunning, ref mode, ref iterationNo, ref totalRetailCost, ref totalTradeCost, ref totalProductQuantity, ref totalProfitValue);
                }

                iterationNo = +1;

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
                            break;
                    }
                }
                productQuantity = integerParsedReturn("Enter number of products required: ");

                if (productQuantity > discountQuantity)
                {
                    tradeCost = (tradeCost * (1.0m - discountPercent));
                }

                profitValue = productQuantity * (retailCost - (tradeCost * (1 + vatValue)));

                totalRetailCost = +retailCost;
                totalTradeCost = +tradeCost;
                totalProductQuantity = +productQuantity;
                totalProfitValue = +profitValue;

                Console.WriteLine("Data Set: {0}", iterationNo);
                Console.WriteLine("\nRetail Cost: {0}; Trade Cost: {1}; Product Quantity: {2}; Profit: {3};", retailCost, tradeCost, productQuantity, profitValue);
                Console.ReadLine();

                systemCleanup(ref modeSelected, ref productSelected, ref systemRunning);
            }
            systemCleanup(ref modeSelected, ref productSelected, ref systemRunning);
            systemModeSelector(ref modeSelected, ref systemRunning, ref mode, ref iterationNo, ref totalRetailCost, ref totalTradeCost, ref totalProductQuantity, ref totalProfitValue);
        }

        static void systemModeSelector(ref bool modeSelected, ref bool systemRunning, ref string mode, ref int iterationNo, ref decimal totalRetailCost, ref decimal totalTradeCost, ref int totalProductQuantity, ref decimal totalProfitValue)
        {
            while (!modeSelected)
            {
                Console.Write("\nEnter (S)ale or (E)nd of Day: ");
                mode = Console.ReadLine();

                switch (mode.ToLower())
                {
                    case "s":
                        Console.WriteLine("\n--Sales Mode--");
                        systemRunning = true;
                        modeSelected = true;
                        break;
                    case "e":
                        Console.WriteLine("\n--End of Day--");
                        systemRunning = false;
                        modeSelected = true;
                        dataCollation(ref systemRunning, ref iterationNo, ref totalRetailCost, ref totalTradeCost, ref totalProductQuantity, ref totalProfitValue);
                        break;
                    default:
                        break;
                }
            }
        }

        static void dataCollation(ref bool systemRunning, ref int iterationNo, ref decimal totalRetailCost, ref decimal totalTradeCost, ref int totalProductQuantity, ref decimal totalProfitValue)
        {
            Console.WriteLine("\nNumber of Data Sets: {0}", iterationNo);
            Console.WriteLine("\nTotal Retail Cost: {0}; Total Trade Cost: {1}; Total Product Quantity: {2}; Total Profit: {3};", totalRetailCost, totalTradeCost, totalProductQuantity, totalProfitValue);
            Console.WriteLine("\n--System End--");
            systemRunning = false;
            Console.ReadLine();
        }

        static void systemCleanup(ref bool modeSelected, ref bool productSelected, ref bool systemRunning)
        {
            modeSelected = false;
            productSelected = false;
            systemRunning = false;
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