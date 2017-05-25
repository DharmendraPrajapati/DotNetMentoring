using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.VehiclesTypes
{
    public class Bus : IVehicle
    {
        public double PeopleCapacity { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return " Bus People Capacity: " + PeopleCapacity + " Bus RegNo: " + RegNo + " Bus Name: " + Name + "\n";
        }
    }
}