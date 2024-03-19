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
