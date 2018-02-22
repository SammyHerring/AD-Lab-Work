//Project Name: Lab 5 - Exercise 1 Zoo Calc AV | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 22/2/2018 | 13:26
//Last Updated On:  22/2/2018 | 13:49
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5___Exercise_1_Zoo_Calc_AV
{
    class Program
    {
        static void Main(string[] args)
        {

            // prices ratecard, ticket
            // pratecard 0..4
            // ticket 0=adult, 1=child, 2= senior,  3=pass, 4=group,

            decimal[,] ticketPrices = new decimal[5, 5];
            int rateCardLoop;
            int[,] ticketTimes = {{12, 14, 15}, {12, 14, 15}, {12, 14, 15},
                                         {12, 15, 17}, {12, 15, 17}, {12, 15, 17},
                                         {12, 16, 19}, {12, 16, 19},
                                         {12, 15, 17},
                                         {12, 14, 15}, {12, 15, 15}, {12, 14, 15}};

            //month, ratecard
            int[,] rateCardTimes = {{3, 4, 5}, {3, 4, 5}, {3, 4, 5},
                                       {2, 3, 4}, {2, 3, 4}, {2, 3, 4},
                                       {1, 2, 3}, {1, 2, 3},
                                       {2, 3, 4},
                                       {3, 4, 5}, {3, 4, 5}, {3, 4, 5}};
            int ticketLoop;

            string[] monthNames ={"january", "february", "march", "april", "may", "june",
                                  "july", "august", "september", "october", "november", "december"};

            int rateCard;

            int numAdultTickets;
            int numChildTickets;
            int numSeniorTickets;
            decimal totalCost;
            decimal rawTotalCost;
            int totalTickets;

            decimal adultTicketPrice;
            decimal childTicketPrice;
            decimal seniorTicketPrice;
            decimal passTicketPrice;
            decimal groupTicketPrice;

            // 0 = adult, 1 = child, 2=senior, 3 = pass, 4 = group
            const int ADULT = 0;
            const int CHILD = 1;
            const int SENIOR = 2;
            const int PASS = 3;
            const int GROUP = 4;

            int[] ticketsSold = new int[5];
            decimal totalIncome = 0.0M;

            string monthName;
            int monthNum;
            int timeHour;

            int monthLoop;
            int timeLoop;
            int timeSlotToUse = 0;

            string anotherTicket = "Y";

            //open file
            StreamReader monthFile = new StreamReader("prices.txt");
            decimal fileValue;

            for (rateCardLoop = 0; rateCardLoop < 5; rateCardLoop++)
            {
                for (ticketLoop = 0; ticketLoop < 5; ticketLoop++)
                {
                    try
                    {
                        fileValue = decimal.Parse(monthFile.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        fileValue = 0.0M;
                    }

                    ticketPrices[rateCardLoop, ticketLoop] = fileValue;
                }
            }

            //close file
            monthFile.Close();



            //input month and time
            Console.WriteLine("What month is it?");
            monthName = Console.ReadLine();

            while (anotherTicket.ToUpper() == "Y")
            {
                Console.WriteLine("What hour is it? 24 hour clock");
                timeHour = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter number of Adult Tickets Required");
                numAdultTickets = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter number of Child Tickets Required");
                numChildTickets = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter number of Senior Tickets Required");
                numSeniorTickets = int.Parse(Console.ReadLine());

                // find month number
                monthNum = -1;
                for (monthLoop = 0; monthLoop < 12; monthLoop++)
                {
                    if (monthName.ToLower() == monthNames[monthLoop].ToLower())
                    {
                        // found it
                        monthNum = monthLoop;
                    }
                }

                if (monthNum == -1)
                {
                    //    'monthname not found!
                    Console.WriteLine("Month name not found, exiting");
                    Console.ReadLine();
                    return;
                }


                // find the appropriate cost row
                for (timeLoop = 0; timeLoop < 3; timeLoop++)
                {
                    if (ticketTimes[monthNum, timeLoop] >= timeHour)
                    {
                        timeSlotToUse = timeLoop;
                        //exit for
                        break;
                    }
                }

                rateCard = rateCardTimes[monthNum, timeSlotToUse] - 1;

                adultTicketPrice = ticketPrices[rateCard, ADULT];
                childTicketPrice = ticketPrices[rateCard, CHILD];
                seniorTicketPrice = ticketPrices[rateCard, SENIOR];
                passTicketPrice = ticketPrices[rateCard, PASS];
                groupTicketPrice = ticketPrices[rateCard, GROUP];

                totalTickets = numAdultTickets + numChildTickets + numSeniorTickets;

                if (totalTickets >= 5)
                {
                    //true
                    totalCost = totalTickets * groupTicketPrice;
                    Console.WriteLine("Selling Group Tickets");
                    ticketsSold[4] += totalTickets;
                }
                else
                {
                    //false
                    rawTotalCost = (adultTicketPrice * numAdultTickets) + (childTicketPrice * numChildTickets)
                                   + (seniorTicketPrice * numSeniorTickets);
                    if (rawTotalCost > passTicketPrice)
                    {
                        // sell pass ticket
                        totalCost = passTicketPrice;
                        Console.WriteLine("Selling a 'Pass' Ticket");
                        ticketsSold[3] += 1;
                    }
                    else
                    {
                        //'sell individual
                        totalCost = rawTotalCost;
                        Console.WriteLine("Selling individual Tickets");
                        ticketsSold[0] += numAdultTickets;
                        ticketsSold[1] += numChildTickets;
                        ticketsSold[2] += numSeniorTickets;
                    }

                }

                Console.WriteLine("Total Price =  £" + totalCost.ToString());
                totalIncome += totalCost;


                Console.WriteLine("Do you need to sell more tickets? (Y/N)");
                anotherTicket = Console.ReadLine();
            }  //End While

            Console.WriteLine();
            Console.WriteLine("Days Figures");
            Console.WriteLine("Total Takings: £" + totalIncome.ToString());
            Console.WriteLine("Num Adult Tickets:  " + "");
            Console.WriteLine("Num Child Tickets:  " + "");
            Console.WriteLine("Num Senior Tickets: " + "");
            Console.WriteLine("Num Pass Tickets:   " + "");
            Console.WriteLine("Num Group Tickets:  " + "");

            Console.ReadLine();


        }
    }
}
