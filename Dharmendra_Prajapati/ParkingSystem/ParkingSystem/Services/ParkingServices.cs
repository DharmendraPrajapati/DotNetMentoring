using ParkingSystem.Model;
using System.Linq;
using ParkingSystem.Interfaces;

namespace ParkingSystem.Services
{
    internal class ParkingServices<T> : IParkingService<T>
    {
        private readonly ParkingSystem<T> _parkingObject;
        public ParkingServices(ParkingSystem<T> parkingSysObj)
        {
            _parkingObject = parkingSysObj;
        }

        public int GetAllSlots()
        {
            return _parkingObject.Floors.Sum(floorObj => floorObj.Capacity);
        }

        public int GetAllSlots(int floorNumber)
        {
            return _parkingObject.Floors.Where(a => a.FloorNumber == floorNumber).Sum(floorObj => floorObj.Capacity);
        }
        public int GetAllAvailableSlots()
        {
            return _parkingObject.Floors.Sum(floorObj => (floorObj.Capacity - floorObj.ParkingSlots.Count(a => a.IsAvailable == false)));
        }

        public bool AddCar(Car<T> carObj)
        {
            foreach (var floor in _parkingObject.Floors)
            {
                if (floor.Capacity <= floor.ParkingSlots.Count)
                {
                    continue;
                }

                floor.ParkingSlots.Add(new ParkingSlots<T> { Car = carObj, IsAvailable = false, SlotNumber = floor.ParkingSlots.Max(a => a.SlotNumber) });

                return true;
            }
            return false;
        }

        public void RemoveCar(int floorNum, int slotNumber)
        {
            foreach (var floor in _parkingObject.Floors)
            {
                if (floor.FloorNumber != floorNum)
                {
                    continue;
                }

                foreach (var slot in floor.ParkingSlots)
                {
                    if (slot.SlotNumber == slotNumber)
                    {
                        slot.IsAvailable = true;
                    }
                }
            }
        }
    }
}
