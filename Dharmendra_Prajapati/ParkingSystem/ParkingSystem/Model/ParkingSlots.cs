using System.Collections.Generic;

namespace ParkingSystem.Model
{
    internal class ParkingSlots<T>
    {
        public int SlotNumber { get; set; }
        public Car<T> Car { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
