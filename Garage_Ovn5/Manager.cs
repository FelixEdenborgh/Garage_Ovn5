using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Denna klassen är där menyn och allt ska vara i
namespace Garage_Ovn5
{
    public class Manager
    {
        public void Run()
        {
            bool running = true;
            int numberOfParkingSlots = 0;
            int numberOfVehiclesFromStart = 0;

            // Skapa garaget och lägger på hur många platser från start det ska ha
            Console.WriteLine("Hej och välkommen till att sätta upp detta Garage" +
                " hur många platser ska finnas i den?");
            numberOfParkingSlots = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur många fordon ska finnas från start, svara i siffror: ");
            numberOfVehiclesFromStart = Convert.ToInt32(Console.ReadLine());

            while (running)
            {
                Console.WriteLine("Välkommen till detta Garage");
                Console.WriteLine("Välj alternativ: ");
                Console.WriteLine("1. Vissa alla parkerade fordon +" +
                    "\n2. Vissa alla fordons typer " +
                    "\n3. Lägg till fordon i garaget" +
                    "\n4. Ta bort fordon från garaget" +
                    "\n5. Sök efter specifikt fordon från registerings nummer" +
                    "\n6. Sök efter fordon utifrån en egenskap" +
                    "\n7. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Vad för fordon vill du lägga till?: ");
                        break;
                    case 4:
                        Console.WriteLine("Vad för fordon vill du ta bort?: ");
                        break;
                    case 5:
                        Console.WriteLine("Vi utgår ifrån bara Svenska regesterings nummer t ex 'ABC123'");
                        Console.WriteLine("Vilket registerings nummer vill du söka på: ");
                        break;
                    case 6:
                        Console.WriteLine("Sök efter egenskap på fordon: ");
                        break;
                    case 7:
                        Console.WriteLine("Garaget stängs nu.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Det där var inget val");
                        break;
                }

            }


            

        }
    }
}
