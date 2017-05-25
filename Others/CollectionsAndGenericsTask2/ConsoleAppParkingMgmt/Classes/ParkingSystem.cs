using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.Classes
{
    public class ParkingSystem : IParkingSystem
    {
        public ParkingSystem(List<Floor> floors)
        {
            Floors = floors;
        }

        public List<Floor> Floors { get; set; }
        
        public string Name { get; set; }
        public string ParkingSystemLocation { get; set; }

        public void AddFloors(IEnumerable<Floor> floors)
        {
            Floors.AddRange(floors);
        }

        public void AddFloor(Floor floor)
        {
            Floors.Add(floor);
        }

        public void RemoveFloor(int id)
        {
            var floor = Floors.FirstOrDefault(flr => flr.FloorNo == id);
            Floors.Remove(floor);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var allEmptySlots = 0;
            var allParkingSlots = 0;
            stringBuilder.Append(" Parking System Name: " + Name + " Parking System Location: " + ParkingSystemLocation+ "\n");
            foreach(var floor in Floors)
            {
                stringBuilder.Append("\n" + floor);
                foreach(var parkingSlot in floor.ParkingSlots)
                {
                    stringBuilder.Append(parkingSlot + "\n");
                    stringBuilder.Append(" Empty Parking Slots: " + parkingSlot.GetEmptySlots() + "\n");
                    var slots = parkingSlot.Slots;
                    foreach(var slot in slots)
                    {
                        stringBuilder.Append(slot);
                    }
                    allEmptySlots += parkingSlot.GetEmptySlots();
                    allParkingSlots += slots.Count;
                }
                stringBuilder.Append(" Total No.of Empty Slots In the System: " + allEmptySlots + "\n");
                stringBuilder.Append(" All parking Slots In the System: " + allParkingSlots + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}