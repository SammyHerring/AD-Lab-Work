using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherPredictorCSharp
{
    class Program
    {
        static void Main()
        {
            double rainfall = 0;
            int pressure = 0;
            int prevPressure = 0;
            int pressureDrop = 0;
            double cloudCover = 0;
            double cloudCoverEigths = 0;
            int Temperature = 0;
            int windDirection = 0;
            double weatherValueFactor = 0;

            double predictedRain = 0;
            int predictedTemp = 0;
            int predictedWind = 0;

            Console.WriteLine("Weather Predictor");
            Console.WriteLine("What direction is the wind coming from? (Enter degrees from north.)");
            windDirection = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter current pressure in millibars:");
            pressure = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter previous pressure in reading:");
            prevPressure = Convert.ToInt32(Console.ReadLine());

            pressureDrop = prevPressure - pressure;

            Console.WriteLine("Enter rainfall as cm in last 24 hours:");
            rainfall = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter current cloud cover as number of 1/8ths of cloud:");
            cloudCover = Convert.ToInt32(Console.ReadLine());

            cloudCoverEigths = 1 / cloudCover;

            Console.WriteLine("Enter temperature as degrees C:");
            Temperature = Convert.ToInt32(Console.ReadLine());

            weatherValueFactor = pressureDrop * (15 - Temperature);

            predictedWind = (windDirection + 30) % 360;

            if (weatherValueFactor < 0)
            {
                // better
                predictedTemp = Temperature + 5;
                predictedRain = Math.Max(0, rainfall * 0.6);
            }
            else if ((weatherValueFactor > 1) && (weatherValueFactor < 60))
            {
                // slightly worse
                if ((windDirection > 180) && (windDirection < 250))
                {
                    predictedRain = rainfall + weatherValueFactor / 10;
                }
                else
                {
                    predictedRain = rainfall + weatherValueFactor / 20 + cloudCoverEigths * 10;
                }

                predictedTemp = Temperature - pressureDrop / 5;
            }
            else
            {
                // much worse
                if ((windDirection > 190) && (windDirection < 255))
                {
                    predictedRain = rainfall + weatherValueFactor / 3;
                    predictedTemp = Temperature - pressureDrop / 2;
                }
                else if (((windDirection > 345) && (windDirection < 359)) || ((windDirection > -30) && (windDirection < 35)))
                {
                    predictedRain = rainfall / predictedRain / 2;
                    predictedTemp = Temperature - Convert.ToInt32(weatherValueFactor) / 5;
                }
                else
                {
                    predictedRain = rainfall + weatherValueFactor / 8;
                    predictedTemp = predictedTemp - Convert.ToInt32(weatherValueFactor) / 7;
                }
            }

            Console.WriteLine("Wind direction will be: " + Convert.ToString(predictedWind));
            Console.WriteLine("Temperature will be: " + Convert.ToString(predictedTemp));
            Console.WriteLine("Rainfall will be: " + Convert.ToString(predictedRain));

            Console.ReadLine();
        }
    }
}