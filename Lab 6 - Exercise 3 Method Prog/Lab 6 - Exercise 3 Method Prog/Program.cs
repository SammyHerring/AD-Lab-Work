//Project Name: Lab 6 - Exercise 3 Method Prog | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 8/3/2018 | 13:25
//Last Updated On:  8/3/2018 | 15:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6___Exercise_3_Method_Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = "";
            while (destination == "")
            {
                Console.WriteLine("Enter requested destination: ");
                destination = Console.ReadLine();
            }
            Console.WriteLine("Ticket Cost ({0}): {1:C2}", FirstCharToUpper(destination), ticketPriceReturn(ref destination));
            Console.WriteLine(destination); //Bug with Destination Procedure, as ticketPriceReturn is called after statement
            Console.ReadLine();
        }

        static decimal ticketPriceReturn(ref string destination)
        {
            string destinationChar = destination.Substring(0, 1).ToLower();
            decimal ticketPrice;

            switch (destinationChar)
            {
                case "l": //London
                    ticketPrice = 13.90m;
                    break;
                case "p": //Paris
                    ticketPrice = 35.80m;
                    break;
                case "b": //Bruges
                    ticketPrice = 39.90m;
                    break;
                default:
                    destination = "";
                    while (destination == "")
                    {
                        Console.WriteLine("Enter requested destination: ");
                        destination = Console.ReadLine();
                        destinationChar = destination.Substring(0, 1).ToLower();
                    }

                    ticketPrice = ticketPriceReturn(ref destination);
                    break;
            }
            return ticketPrice;
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Stupid programmer alert!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        //while (!int.TryParse(Console.ReadLine(), out int destination))
        //{
        //    Console.WriteLine("Please enter a valid integer");
        //}
    }
}
