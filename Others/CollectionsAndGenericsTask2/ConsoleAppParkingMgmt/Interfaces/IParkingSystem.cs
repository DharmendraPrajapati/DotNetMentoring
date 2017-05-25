using System.Collections.Generic;
using ConsoleAppParkingMgmt.Classes;

namespace ConsoleAppParkingMgmt.Interfaces
{
    public interface IParkingSystem
    {
        void AddFloors(IEnumerable<Floor> floors);

        void AddFloor(Floor floor);

        void RemoveFloor(int id);

    }
}