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
        private Garage<Vehicle>? garage = null;

        //public Manager(Garage<Vehicle> garage)
        //{
        //    this.garage = garage;
        //}

        public void Run()
        {
            bool running = true;
            bool start = true;

            int numberOfParkingSlots = 0;
            string? input = string.Empty;
            int numberOfVehiclesFromStart = 0;
           

            while (start)
            {
                // Skapa garaget och lägger på hur många platser från start det ska ha
                Console.WriteLine("Hej och välkommen till att sätta upp detta Garage" +
                    " hur många platser ska finnas i den. Svara i siffor: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out numberOfParkingSlots))
                {
                    // Kontrollera om antalet platser är mindre än det minsta tillåtna antalet
                    if (numberOfParkingSlots < 5)
                    {
                        Console.WriteLine("Antalet platser kan inte vara mindre än 5. Sätter automatiskt till 5.");
                        numberOfParkingSlots = 5;
                    }

                    // Skapa garage med x amount of platser:
                    this.garage = new Garage<Vehicle>(numberOfParkingSlots); // skapar ett garage och sätter det till storleken av användar input
                }
                else
                {
                    Console.WriteLine("Ogiltig input. Ange ett heltal.");
                }


                

                // Skapar hur många fordon som användaren vill ha och sätter dem i Generic T "arrayn"
                Console.WriteLine("Hur många fordon ska finnas från start, svara i siffror: ");
                string? input2 = Console.ReadLine();

                if(int.TryParse(input2, out numberOfVehiclesFromStart))
                {
                    for(int i = 0; i < numberOfVehiclesFromStart; i++)
                    {
                        Vehicle vehicle = VehicleFactory.CreateRandomVehicle();
                        AddVehicleToGarage(vehicle);
                    }
                    start = false; // avslutar loopen
                }
                else
                {
                    Console.WriteLine("Ogiltig input. Ange hur många fordon från start som ska sättas. Svara i heltal");
                }

            }
            


            while (running)
            {
                Console.WriteLine("Välkommen till detta Garage");
                Console.WriteLine("Välj alternativ: ");
                Console.WriteLine("1. Vissa alla parkerade fordon" +
                    "\n2. Vissa alla fordons typer" +
                    "\n3. Lägg till fordon i garaget" +
                    "\n4. Ta bort fordon från garaget" +
                    "\n5. Sök efter specifikt fordon från registerings nummer" +
                    "\n6. Sök efter fordon utifrån en egenskap" +
                    "\n7. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        ShowAllVehicles();
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
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }


            

        }


        // Hanterar AddVehicle() metoden i Garage klassen för att lägga till ett fordon
        public void AddVehicleToGarage(Vehicle vehicle)
        {
            if(garage == null)
            {
                Console.WriteLine("Garaget har inte skapats än. Ange antal PaerkeringsPlatser.");
                return;
            }

            if (!garage.AddVehicle(vehicle))
            {
                Console.WriteLine("Garaget är fullt, kunde inte lägga till fordonet.");
            }
            else
            {
                Console.WriteLine("Fordonet har lagts till i garaget.");
            }
        }

        // Vissa alla fordon
        public void ShowAllVehicles()
        {
            foreach(var vehicle in garage)
            {
                Console.WriteLine($"Type: {vehicle.GetType().Name}\nRegNumber: {vehicle.RegistrationNumber}\nColor: {vehicle.ColorOfVehicle}\n" +
                    $"Number Of Wheels: {vehicle.NumberOfWheels}\nHorse Power: {vehicle.HorsePower}" );
                Console.WriteLine();
            }
        }

    }
}
