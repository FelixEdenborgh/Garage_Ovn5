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

            // Settings på fordon
            bool hasSail = false;
            string? fuel = string.Empty;
            int engines = 0;
            int wheels = 0;
            bool lightsOn = false;
            int numberOfSeats = 0;
            int horsePower = 0;

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
                        ShowAllVehicleTypes();
                        break;
                    case 3:
                        // Skapandet av vehicle
                        Console.WriteLine("Hur många däck har den svara i heltal: ");
                        string? howManyWheels = Console.ReadLine();
                        if (int.TryParse(howManyWheels, out wheels)) 
                        {
                        }
                        else
                        {
                            Console.WriteLine("Inte ett giltigt input.");
                        }

                        Console.WriteLine("Vilken färg ska fordonet vara i?: ");
                        string? color = Console.ReadLine();
                        if(color == null)
                        {
                            color = "Red";
                        }

                        Console.WriteLine("Vi använder oss av Svenska registerings nummer här\nVilket registerings nummer ska ditt fordon ha?: ");
                        string? regNumberinput = Console.ReadLine(); // Steg 1: Läs in input.

                        // Steg 2 och 3: Kontrollera om input är null. Använd standardvärdet eller konvertera till versaler.
                        string regNumber;
                        if (regNumberinput == null)
                        {
                            regNumber = "ABC123"; // Standardvärde om input är null.
                        }
                        else
                        {
                            regNumber = regNumberinput.ToUpper(); // Konvertera till versaler om input inte är null.
                        }

                        Console.WriteLine("Hur många häst krafter har fordonet?: ");
                        string? horsePowerInput = Console.ReadLine();
                        if (horsePowerInput == null){}
                        else
                        {
                            if (!int.TryParse(horsePowerInput, out horsePower))
                            {
                                horsePower = 10;
                            }
                        }
                        


                        Console.WriteLine("Det finns Car, Boat, Plane, MotorCycle, Buss");
                        Console.WriteLine("Vad för fordon vill du lägga till?: ");
                        string? typeOfVehicle = Console.ReadLine();
                        if (typeOfVehicle == null)
                        {
                            typeOfVehicle = "Car"; // om den är null så hård kodas den till bil
                            Console.WriteLine("Vad för Fuel använder den?: ");
                            fuel = Console.ReadLine();
                            if (fuel == null)
                            {
                                fuel = "Bensin";
                            }
                            // lägg till fordonet
                            var car = new Car(wheels, color, horsePower, regNumber, fuel);
                            AddVehicleToGarage(car);
                        }
                        else if (typeOfVehicle == "Car")
                        {
                            Console.WriteLine("Vad för Fuel använder den?: ");
                            fuel = Console.ReadLine();
                            if (fuel == null)
                            {
                                fuel = "Bensin";
                            }
                            // lägg till fordonet
                            var car = new Car(wheels, color, horsePower, regNumber, fuel);
                            AddVehicleToGarage(car);
                        }
                        else if (typeOfVehicle == "Boat")
                        {
                            Console.WriteLine("Har den ett segel? svara ja/ nej: ");
                            string? hasSailInput = Console.ReadLine();

                            if (hasSailInput != null)
                            {
                                // Förvandla input till små bokstäver för att göra jämförelsen skiftlägesokänslig
                                string sail = hasSailInput.ToLower();

                                // Kontrollera om användaren svarade "ja"
                                if (sail == "ja")
                                {
                                    hasSail = true;
                                }
                                // Inget behov av att explicit sätta hasSail till false igen, det är redan standardvärdet.
                            }


                            // lägg till fordonet
                            var boat = new Boat(wheels, color, horsePower, regNumber, hasSail);
                            AddVehicleToGarage(boat);
                        }
                        else if (typeOfVehicle == "Plane")
                        {
                            Console.WriteLine("Hur många motorer har Planet?: ");
                            string? numberOfEngines = Console.ReadLine();

                            if (!int.TryParse(numberOfEngines, out engines))
                            {
                                engines = 2; // Sätter standardvärdet till 2 om inmatningen inte är ett giltigt heltal
                            }

                            // lägg till fordonet
                            var plane = new Plane(wheels, color, horsePower, regNumber, engines);
                            AddVehicleToGarage(plane);
                        }
                        else if (typeOfVehicle == "MotorCycle")
                        {
                            Console.WriteLine("Har MotorCyckeln lampan på? Svara i ja / nej: ");
                            string? lightsOnInput = Console.ReadLine();
                            if (lightsOnInput != null)
                            {
                                // Förvandla input till små bokstäver för att göra jämförelsen skiftlägesokänslig
                                string light = lightsOnInput.ToLower();

                                // Kontrollera om användaren svarade "ja"
                                if (light == "ja")
                                {
                                    lightsOn = true;
                                }
                                // Inget behov av att explicit sätta hasSail till false igen, det är redan standardvärdet.
                            }

                            // lägg till fordonet
                            var motorCycle = new MotorCycle(wheels, color, horsePower, regNumber, lightsOn);
                            AddVehicleToGarage(motorCycle);
                        }
                        else if (typeOfVehicle == "Buss")
                        {
                            Console.WriteLine("Hur många platser finns det på din buss?: ");
                            string? numberOfSeatsInput = Console.ReadLine();
                            if(!int.TryParse(numberOfSeatsInput, out numberOfSeats))
                            {
                                numberOfSeats = 10;
                            }

                            // lägg till fordonet
                            var buss = new Bus(wheels, color, horsePower, regNumber, numberOfSeats);
                            AddVehicleToGarage(buss);
                        }
                        else
                        {
                            typeOfVehicle = "Car"; // om den är satt som något som inte finns att välja på så hård kodas den till bil
                            Console.WriteLine("Vad för Fuel använder den?: ");
                            fuel = Console.ReadLine();
                            if (fuel == null)
                            {
                                fuel = "Bensin";
                            }

                            // lägg till fordonet
                            var car = new Car(wheels, color, horsePower, regNumber, fuel);
                            AddVehicleToGarage(car);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Registerings nummer att välja på: ");
                        ShowAllRegisterNumbers();
                        Console.WriteLine("Ange registerings numret på den du vill ta bort: ");
                        string? regNumberToRemove = Console.ReadLine();
                        if(regNumberToRemove == null) { 
                        }
                        else
                        {
                            RemoveVehicleFromGarage(regNumberToRemove);
                        }
                        break;
                    case 5:
                        ShowAllRegisterNumbers();
                        Console.WriteLine("Vi utgår ifrån bara Svenska regesterings nummer t ex 'ABC123'");
                        Console.WriteLine("Vilket registerings nummer vill du söka på: ");
                        string? regNumberToBeFound = Console.ReadLine();
                        if(regNumberToBeFound == null) { }
                        else
                        {
                            LocateVehicleFromGarage(regNumberToBeFound);
                        }
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


        // Hitta fordonet baserat på registeringsnummer
        private void LocateVehicleFromGarage(string regNumber)
        {
            if(garage.FindVehicleBasedOnRegistrationNumber(regNumber))
            {
                Console.WriteLine("Fordonet har hittats");
            }
            else
            {
                Console.WriteLine("Inget fordon hittades med det registeringsnumret.");
            }
        }

        // Ta bort ett fordon baserat på registeringsnummer
        private void RemoveVehicleFromGarage(string regnumberToRemove)
        {
            if (garage.RemoveVehicle(regnumberToRemove))
            {
                Console.WriteLine("Fordonet har tagits bort.");
            }
            else
            {
                Console.WriteLine("Inget fordon hittades med det registeringsnumret.");
            }
        }

        // Visa alla fordons typer
        private void ShowAllVehicleTypes()
        {
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"Type: {vehicle.GetType()}");
                Console.WriteLine();
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

        // Vissa alla fordons registerings nummer
        public void ShowAllRegisterNumbers()
        {
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"RegNumber: {vehicle.RegistrationNumber}");
                Console.WriteLine();
            }
        }

    }
}
