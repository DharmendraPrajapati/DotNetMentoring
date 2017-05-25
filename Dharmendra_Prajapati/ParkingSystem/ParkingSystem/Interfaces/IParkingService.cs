using ParkingSystem.Model;

namespace ParkingSystem.Interfaces
{
    internal interface IParkingService<T>
    {
        int GetAllSlots();
        int GetAllSlots(int floorNumber);
        int GetAllAvailableSlots();
        bool AddCar(Car<T> carObj);
        void RemoveCar(int floorNum, int slotNumber);
    }
}
