using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.VehiclesTypes
{
    public class Truck : IVehicle
    {
        public double LoadCapacity { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return " Truck Load Capacity: " + LoadCapacity + " Truck RegNo: " + RegNo + " Truck Name: " + Name +"\n";
        }
    }
}