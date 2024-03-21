namespace Garage_Ovn5.Interface
{
    public interface IGarage<T> where T : Vehicle
    {
        int Capacity { get; }
        int Count { get; }

        bool AddVehicle(T vehicle);
        T? FindVehicleBasedOnRegistrationNumber(string regNumber);
        IEnumerable<T> FindVehiclesByProperty(string propertyName, object value);
        IEnumerator<T> GetEnumerator();
        bool RemoveVehicle(string registrationNumber);
    }
}