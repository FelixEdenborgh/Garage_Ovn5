using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Ovn5
{

    // Sköter random skapandet av fordonen
    public static class VehicleFactory
    {
        private static Random random = new Random();

        public static Vehicle CreateRandomVehicle()
        {
            // Slumpar ut vad för fordons typ det ska vara
            int vehicleType = random.Next(1, 5); // 1=Car 2=Boat 3=MororCycle 4=Plane 5=Bus

            // Slumpar hur många hjul
            int wheels = random.Next(2, 8);

            // Slumpar häst krafterna
            int horsePower = random.Next(50, 250);

            // Slumpar om det är true eller false, för om båten har segel eller inte, eller om lampan är på eller ej
            bool rightOrWrong = random.Next(2) == 1;

            // Slumpar på vad för färg
            int colors = random.Next(1, 5); // 1=Röd 2=Blå 3=Svar 4=Grön 5=Lila
            string color = string.Empty;

            switch (colors)
            {
                case 1:
                    color = "Red";
                    break;
                case 2:
                    color = "Blue";
                    break;
                case 3:
                    color = "Black";
                    break;
                case 4:
                    color = "Green";
                    break;
                case 5:
                    color = "Purple";
                    break;
                default:
                    color = "Yellow";
                    break;
            }


            switch (vehicleType)
            {
                case 1:
                    return new Car(wheels, color, horsePower, GenerateRandomRegistrationNumber(), "Gasolin");
                case 2:
                    return new Boat(wheels, color, horsePower, GenerateRandomRegistrationNumber(), rightOrWrong);
                case 3:
                    return new MotorCycle(wheels, color, horsePower, GenerateRandomRegistrationNumber(), rightOrWrong);
                case 4:
                    return new Plane(wheels, color, horsePower, GenerateRandomRegistrationNumber(), 2);
                case 5:
                    return new Bus(wheels, color, horsePower, GenerateRandomRegistrationNumber(), 20);
                default:
                    // Standard bil om inget blir rätt
                    return new Car(4, "SapphireSvart", 200, "HBR490", "Bensin");
            }
        }

        // Skaffar ett random registerings nummer
        public static string GenerateRandomRegistrationNumber()
        {
            Random random = new Random();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";

            // Skapa de tre bokstäverna
            string registrationLetters = new string(Enumerable.Repeat(letters, 3)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());

            // Skapa de tre siffrorna
            string registrationNumbers = new string(Enumerable.Repeat(numbers, 3)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());

            return registrationLetters + registrationNumbers;
        }

    }
}
