//Project Name: Lab 5 - Exercise 3 Arr Methods | File Name: Program.cs
//Author Name: Samuel Steven David Herring
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 22/2/2018 | 14:28
//Last Updated On:  22/2/2018 | 14:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5___Exercise_3_Arr_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1

            int[] ages = new int[7];
            string[] names = new string[7];
            int loopCounter;
            int whichOne;

            for (loopCounter = 0; loopCounter < 7; loopCounter++)
            {
                Console.WriteLine("Please enter a name");
                names[loopCounter] = Console.ReadLine();
                Console.WriteLine("Please enter their age");
                ages[loopCounter] = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("Enter a number 0-6, or -1 to end");
            whichOne = int.Parse(Console.ReadLine());

            while (whichOne != -1)
            {
                Console.WriteLine(names[whichOne] + " is ");
                Console.WriteLine(ages[whichOne].ToString());
                Console.WriteLine("Enter a number 0-6, or -1 to end");
                whichOne = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Press any key");
            Console.ReadKey();

            //Task 2
            int[] numberArray = new int[21];
            int loopCount;
            int num1;
            int num2;

            numberArray[0] = 1;
            numberArray[1] = 1;

            for (loopCount = 2; loopCount < 21; loopCount++)
            {
                num1 = numberArray[loopCount - 1];
                num2 = numberArray[loopCount - 2];
                numberArray[loopCount] = num1 + num2;
            }

            //Write your code here!!!


            //end of your code
            Console.WriteLine("Press a Key");
            Console.ReadKey();

            //Task 3
            string[] places = new String[4];
            double[,] highTides = new double[4, 7];
            double time;
            int tideLoop;
            int locLoop;

            places[0] = "Ramsgate";
            places[1] = "Shoreham-by-Sea";
            places[2] = "Poole";
            places[3] = "Exmouth";
            highTides[0, 0] = 15.9;
            highTides[1, 0] = 15.05;
            highTides[2, 0] = 12.2;
            highTides[3, 0] = 10.25;

            for (tideLoop = 1; tideLoop < 7; tideLoop++)
            {
                for (locLoop = 0; locLoop < 4; locLoop++)
                {
                    highTides[locLoop, tideLoop] = (highTides[locLoop, tideLoop - 1] + 12.6) % 24.0;
                }
            }

            time = highTides[0, 0];
            //displayTime(time)

            //for each location
            //display the location name
            //for each tide
            //display the tide
            //end of tide loop
            //end of location loop


            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();




            //





        }


        void displayTime(double time)
        {
            double hours;
            double minutes;

            hours = Math.Truncate(time);
            minutes = Math.Truncate((time - hours) * 60);
            Console.WriteLine(hours.ToString() + ":" + minutes.ToString());
        }

    }
}
