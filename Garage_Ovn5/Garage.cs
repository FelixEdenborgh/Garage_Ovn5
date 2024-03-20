using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Ovn5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
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
            for(int i = 0; i < count; i++)
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
            for(int i = 0; i < count; i++)
            {
                if(vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Skifta ner alla element efter det borttagna fordonet ett steg
                    for(int j = i; j < count; j++)
                    {
                        vehicles[j] = vehicles[j+1];
                    }
                    // Minska count och nullställ den sista positionen
                    vehicles[--count] = default(T); // tydligen funkar default också.

                    return true; // Fordonet hittades och togs bort
                }

            }
            return false; // Inget fordon med det registreringsnumret hittades
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
