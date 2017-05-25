using System.Collections.Generic;
using ConsoleAppParkingMgmt.Classes;

namespace ConsoleAppParkingMgmt.Interfaces
{
    public interface IParkingSlot
    {
        string Loaction { get; set; }
        List<Slot<IVehicle>> Slots { get;}

        void AddSlot(Slot<IVehicle> slotToAdd);

        void RemoveSlot(int slotToRemove);

        int GetEmptySlots();
    }
}