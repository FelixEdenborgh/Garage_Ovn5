using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Garage_Ovn5.Interface;

namespace Garage_Ovn5
{
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        // Konstruktor
        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
        }

        // lägga till ny vehicle
        public bool AddVehicle(T vehicle)
        {
            if (count >= capacity) return false; // kollar om det får plats ett fordon annars returnar false
            // lägger till ett fordon
            vehicles[count++] = vehicle;
            return true;
        }

        // Hitta fordon baserat på registeringsNummer
        public T? FindVehicleBasedOnRegistrationNumber(string regNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))

                {
                    return vehicles[i];
                }

            }
            return null; // Inget fordon med det registreringsnumret hittades
        }


        // Ta bort vehicle
        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Skifta ner alla element efter det borttagna fordonet ett steg, stoppa innan sista elementet
                    for (int j = i; j < count - 1; j++)
                    {
                        vehicles[j] = vehicles[j + 1];
                    }
                    // Minska count och nullställ den sista positionen
                    vehicles[--count] = default(T)!; // Använd default(T) för att hantera både referens- och värde-typer korrekt

                    return true; // Fordonet hittades och togs bort
                }
            }
            return false; // Inget fordon med det registreringsnumret hittades
        }



        // Hitta vehicle baserat på egenskap
        // Hitta fordon baserat på egenskap och dess värde

        public IEnumerable<T> FindVehiclesByProperty(string propertyName, object value)
        {
            var matchingVehicles = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var vehicle = vehicles[i];
                if (vehicle == null) continue; // Hoppa över om fordonet är null

                PropertyInfo propertyInfo = vehicle.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)!;
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(vehicle);
                    if (propertyValue != null && propertyValue.Equals(value))
                    {
                        matchingVehicles.Add(vehicle);
                    }
                }
            }

            return matchingVehicles;
        }

        // Generisk version av GetEnumerator som används för IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        // Icke-generisk version av GetEnumerator som används för IEnumerable
        // Notera att detta är rätt sätt att anropa den generiska versionen för icke-generiska IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Ingen yield return här. Direkt anrop till den generiska GetEnumerator()
        }
    }
}
