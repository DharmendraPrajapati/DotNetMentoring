using System.Collections.Generic;
using System.Linq;
using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.Classes
{
    public class ParkingSlot : IParkingSlot
    {
        public string Loaction { get; set; }
        public List<Slot<IVehicle>> Slots { get;}

        public ParkingSlot(List<Slot<IVehicle>> slots)
        {
            Slots = slots;
        }

        public void AddSlot(Slot<IVehicle> slotToAdd)
        {
            Slots.Add(slotToAdd);
        }

        public void RemoveSlot(int slotNo)
        {
            var slotToRemove = Slots.FirstOrDefault(slot => slot.SlotNo == slotNo);
            Slots.Remove(slotToRemove);
        }

        public int GetEmptySlots()
        {
            return Slots.Count(slot => slot.Vehicle == null);
        }

        public override string ToString()
        {
            return "\nParking Slot Location: " + Loaction +"\n";
        }
    }
}