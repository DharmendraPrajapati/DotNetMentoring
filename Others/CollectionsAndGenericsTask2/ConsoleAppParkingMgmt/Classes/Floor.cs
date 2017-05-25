using System.Collections.Generic;
using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.Classes
{
    public class Floor : IFloor
    {
        public int FloorNo { get; set; }
        public string FloorLocation { get; set; }
        public int Capacity { get; }
        public List<ParkingSlot> ParkingSlots { get; set; }

        public Floor(List<ParkingSlot> parkingSlots)
        {
            ParkingSlots = parkingSlots;
            Capacity  = ParkingSlots.Count;
        }
        public void AddParkingSlot(ParkingSlot slotToAdd)
        {
            ParkingSlots.Add(slotToAdd);
        }

        public void RemoveParkingSlot(ParkingSlot slotToRemove)
        {
            ParkingSlots.Remove(slotToRemove);
        }

        public override string ToString()
        {            
            return " Floor No: " + FloorNo + " Floor Location: " + FloorLocation + " No.of Locations : " + Capacity + "\n";
        }
    }
}