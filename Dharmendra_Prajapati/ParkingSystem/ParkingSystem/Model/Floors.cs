using System.Collections.Generic;

namespace ParkingSystem.Model
{
    internal class Floors<T>
    {
        public int FloorNumber { get; set; }
        public IList<ParkingSlots<T>> ParkingSlots { get; set; }
        public int Capacity { get; set; }
    }
}
