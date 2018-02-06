using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooCalcPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int numAdults = 0;
            int numChildren = 0;
            int numSeniors = 0;
            int totalPrice = 0;
            int rawPrice = 0;
            int totalTicketNumbers = 0;
            int groupTicketPrice = 0;
                     

            Console.WriteLine("Enter number of Adults");
            numAdults = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of Children");
            numChildren = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter nimber of Seniors");
            numSeniors = int.Parse(Console.ReadLine());

            totalTicketNumbers = (numAdults + numChildren + numSeniors);


            if (totalTicketNumbers >= 5)
            {
                //Sell group ticket
                Console.WriteLine("Selling group ticket at £9 per person");
                totalPrice = groupTicketPrice * totalTicketNumbers;
            }
            else
            {
                rawPrice = rawPrice + 1490 * numAdults + 1090 * numChildren + 990 * numSeniors;
                if (rawPrice > 3990)
                {
                    //Sell pass ticket
                    Console.WriteLine("Selling Pass Ticket for £39-90");
                    totalPrice = 3990;
                } else
                {
                    Console.WriteLine("Selling Individual Tickets");
                    totalPrice = rawPrice;
                }
            }


            Console.Write("Total Cost = ");
            Console.WriteLine(totalPrice);
            Console.ReadLine();

        }
    }
}
