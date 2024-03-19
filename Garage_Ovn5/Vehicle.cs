using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage_Ovn5
{
    public class Vehicle
    {
        // Hur många hjul
        private int numberOfWheels;
        public int NumberOfWheels
        {
            get { return numberOfWheels; }
            set { numberOfWheels = value; }
        }

        // Vilken färg
        private string colorOfVehicle;
        public string ColorOfVehicle
        {
            get { return colorOfVehicle; }
            set { colorOfVehicle = value; }
        }

        private int horsePower;
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        private string registrationNumber;
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                // Kontrollerar att inmatningen matchar mönstret ABC123 (3 bokstäver följt av 3 siffror)
                // Notera att vi använder ToUpper() för att konvertera inmatningen till versaler först
                if (Regex.IsMatch(value.ToUpper(), @"^[A-Z]{3}\d{3}$"))
                {
                    registrationNumber = value.ToUpper();
                }
                else
                {
                    throw new ArgumentException("Ogiltigt registreringsnummer. Måste vara tre bokstäver följt av tre siffror.");
                }
            }  
        }

        // Konstruktor
        public Vehicle(int wheels, string color, int hpower, string registrationN)
        {
            numberOfWheels = wheels;
            colorOfVehicle = color;
            horsePower = hpower;
            registrationNumber = registrationN;
        }
    }

    // Bil
    public class Car : Vehicle
    {
        public string Fuel {  get; set; }
        public Car(int wheels, string color, int hpower, string registrationN, string fuel) : base(wheels, color, hpower, registrationN)
        {
            Fuel = fuel;
        }
    }

    // Båt
    public class Boat : Vehicle
    {
        public bool HasSail { get; set; }
        public Boat(int wheels, string color, int hpower, string registrationN, bool doesHaveSail) : base(wheels, color, hpower, registrationN)
        {
            HasSail = doesHaveSail;
        }
    }

    // FlygPlan
    public class Plane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public Plane(int wheels, string color, int hpower, string registrationN, int numberOfEngines) : base(wheels, color, hpower, registrationN)
        {
            NumberOfEngines = numberOfEngines;
        }
    }

    // MotorCykel
    public class MotorCycle : Vehicle
    {
        public bool LightOn { get; set; }
        public MotorCycle(int wheels, string color, int hpower, string registrationN, bool lightOn) : base(wheels, color, hpower, registrationN)
        {
            LightOn = lightOn;
        }
    }

    // Buss
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(int wheels, string color, int hpower, string registrationN, int numberOfSeats) : base(wheels, color, hpower, registrationN)
        {
            NumberOfSeats = numberOfSeats;
        }
    }

    
}
