using System.Collections.Generic;
using ConsoleAppParkingMgmt.Classes;

namespace ConsoleAppParkingMgmt.Interfaces
{
    public interface IFloor
    {
        List<ParkingSlot> ParkingSlots { get; set; }

        void RemoveParkingSlot(ParkingSlot slotToRemove);

        void AddParkingSlot(ParkingSlot slotToAdd);
    }
}