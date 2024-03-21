using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Ovn5.Interface
{
    public interface IVehicle
    {
        int NumberOfWheels { get; }
        int HorsePower { get; }
        string ColorOfVehicle { get; }
        string RegistrationNumber { get; }

    }
}
