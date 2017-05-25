using ConsoleAppParkingMgmt.Interfaces;
using ConsoleAppParkingMgmt.VehiclesTypes;

namespace ConsoleAppParkingMgmt.Classes
{
    public class Slot<TVehicle> where TVehicle : IVehicle
    {
        public Slot(int slotNo)
        {
            SlotNo = slotNo;
        }

        public int SlotNo { get; set; }
        public TVehicle Vehicle { get; set; }        
        public override string ToString()
        {
            var vehicleString = string.Empty;
            var isEmpty = true;
            
            if(Vehicle is Car)
            {
                var car = Vehicle as Car;
                vehicleString = car.ToString();
            }
            if(Vehicle is Bus)
            {
                var bus = Vehicle as Bus;
                vehicleString = bus.ToString();
            }
            if(Vehicle is Truck)
            {
                var truck = Vehicle as Truck;
                vehicleString = truck.ToString();
            }
            if(vehicleString != string.Empty)
            {
                vehicleString = "\nParked Vehicle Details" + vehicleString + "\n";
                isEmpty = false;
            }
            return "\n Slot No: " + SlotNo + " Is Vacant: " + isEmpty + "\n" + vehicleString;
        }
    }
}