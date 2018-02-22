using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5___Exercise_2_Array_Srch
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
            int[,] hoursWorked = {{15, 15, 20, 18}, {40, 40, 45, 40},
                                  {38, 38, 35, 40}, {40, 40, 40, 40},
                                  {60, 45, 55, 20}, {12, 14, 15, 14}};

            int personLoop = 0;
            int weekLoop = 0;
            string setupChoice = null;

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
                // Do nothing - use the values given in the above declaration
            }

            // Last week's total hours worked.
            int lastWeekTotalHours = 0;
            int week4TotalHoursLoop = 0;

            for (week4TotalHoursLoop = 0; week4TotalHoursLoop <= 5; week4TotalHoursLoop++)
            {
                lastWeekTotalHours += hoursWorked[week4TotalHoursLoop, 3];
            }

            Console.WriteLine("Total hours for week 4: " + Convert.ToString(lastWeekTotalHours));

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

            // Pay per person per week.
            int[,] grossPayPerWeek = new int[6, 4];

            for (personLoop = 0; personLoop <= 5; personLoop++)
            {
                for (weekLoop = 0; weekLoop <= 3; weekLoop++)
                {
                    grossPayPerWeek[personLoop, weekLoop] = hoursWorked[personLoop, weekLoop] * 800;
                }
            }

            // Biggest number of hours.
            int maxHours = 0;
            int maxHoursEmployee = 0;
            int maxHoursWeek = 0;

            maxHours = hoursWorked[maxHoursEmployee, maxHoursWeek];

            for (personLoop = 0; personLoop <= 5; personLoop++)
            {
                for (weekLoop = 0; weekLoop <= 3; weekLoop++)
                {
                    if (maxHours < hoursWorked[personLoop, weekLoop])
                    {
                        // Found a bigger value!
                        maxHours = hoursWorked[personLoop, weekLoop];
                        maxHoursEmployee = personLoop;
                        maxHoursWeek = weekLoop;
                    }
                }
            }

            Console.WriteLine("Max hours: " + Convert.ToString(maxHours));
            Console.WriteLine("Worked by: " + emplNames[maxHoursEmployee]);
            Console.WriteLine("In Week: " + Convert.ToString(maxHoursWeek + 1));

            // Finding all employees who worked fewer than 35 hours.
            // Insert your code for Individual task 1 here!

            for (int personIndex = 0; personIndex <= 5; personIndex++)
            {
                for (int weekIndex = 0; weekIndex <= 3; weekIndex++)
                {
                    if (hoursWorked[personIndex, weekIndex] < 35)
                    {
                        Console.WriteLine(emplNames[personIndex] + " worked " + hoursWorked[personIndex, weekIndex] + " in Week " + (weekIndex + 1));
                    }
                }
            }

            // Wait for enter keypress to finish.
            Console.WriteLine("Press Enter to finish program.");
            Console.ReadLine();
        }
    }
}
