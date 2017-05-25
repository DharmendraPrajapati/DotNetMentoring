using ConsoleAppParkingMgmt.Interfaces;

namespace ConsoleAppParkingMgmt.VehiclesTypes
{
    public class Car : IVehicle
    {
        public double Engine { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return " Car Engine: " + Engine + " Car RegNo: " + RegNo + " Car Name: " + Name +"\n";
        }
    }


}