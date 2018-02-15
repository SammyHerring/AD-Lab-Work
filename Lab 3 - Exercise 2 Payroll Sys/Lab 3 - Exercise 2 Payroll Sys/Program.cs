//Project Name: Lab 3 - Exercise 2 Payroll Sys | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 15/2/2018 | 15:08
//Last Updated On:  15/2/2018 | 15:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3___Exercise_2_Payroll_Sys
{
    class Program
    {
        static void Main()
        {
            // Giving names to each employee.
            //
            // Note the different way of initialising the contents of the array.
            //
            // If we do it in this we do not specify the size, but the size is 
            // inferred from the number of elements.
            //
            // The { and } indicate the start and end of the array initialisation.
            string[] emplNames = { "Dave", "Brian", "Phil", "Richard", "Vlad", "Paul" };

            // Main hours array definition.
            // (Employee5, Week3)
            // Note the way of initialising the 2D array -- it is an array within
            // an array...
            int[,] hoursWorked = {{15, 15, 20, 18},
                                  {40, 40, 45, 40},
                                  {38, 38, 35, 40},
                                  {40, 40, 40, 40},
                                  {60, 45, 55, 20},
                                  {12, 14, 15, 14}};

            int personLoop = 0;
            int weekLoop = 0;
            string setupChoice = null;

            decimal totalPay;

            Console.WriteLine("Do you wish to enter your own data for the array initialisation? (Y/N) ");
            setupChoice = Console.ReadLine();

            if (setupChoice == "Y")
            {
                for (personLoop = 0; personLoop <= 5; personLoop++)
                {
                    Console.WriteLine("Please Enter " + emplNames[personLoop] + "'s Hours");
                    for (weekLoop = 0; weekLoop <= 3; weekLoop++)
                    {
                        Console.WriteLine("Week " + Convert.ToString(weekLoop + 1));
                        hoursWorked[personLoop, weekLoop] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            else
            {
            }

            // What are Phil's hours for the second week?
            // Phil is the 3rd Person -- index -> 2;
            // Second week -- index -> 1
            // Remember: indexes start at 0!

            int philsHoursForWeek2 = 0;
            philsHoursForWeek2 = hoursWorked[2, 1];

            Console.WriteLine("Phil's hours in week 2 were: " + Convert.ToString(philsHoursForWeek2));

            //insert your code for Task 2.5: Brian in Week 3


            // Totalling Vlad's hours.
            // Vlad is the 5th person -- index -> 4

            int vladHourTotal = 0;
            int vladHourWeekLoop = 0;

            for (vladHourWeekLoop = 0; vladHourWeekLoop <= 3; vladHourWeekLoop++)
            {
                vladHourTotal = vladHourTotal + hoursWorked[4, vladHourWeekLoop];
            }

            Console.WriteLine("Vlad's total hours are: " + Convert.ToString(vladHourTotal));


            //Task 2.6: Totalling Pauls Hours



            // Last week's total hours worked.
            int lastWeekTotalHours = 0;
            int week4TotalHoursLoop = 0;

            for (week4TotalHoursLoop = 0; week4TotalHoursLoop <= 5; week4TotalHoursLoop++)
            {
                lastWeekTotalHours += hoursWorked[week4TotalHoursLoop, 3];
            }

            Console.WriteLine("Total hours for week 4: " + Convert.ToString(lastWeekTotalHours));


            //Task 2.7: First week's total hours worked



            // Total hours worked.
            int monthTotalHours = 0;

            for (personLoop = 0; personLoop <= 5; personLoop++)
            {
                for (weekLoop = 0; weekLoop <= 3; weekLoop++)
                {
                    monthTotalHours += hoursWorked[personLoop, weekLoop];
                }
            }

            Console.WriteLine("Total hours worked in month: " + Convert.ToString(monthTotalHours));


            totalPay = monthTotalHours * 8.00M;

            //AllOutput Test - added by SSDH

            // Wait for enter keypress to finish.
            Console.WriteLine("Press Enter to finish program.");
            Console.ReadLine();
        }


    }
}