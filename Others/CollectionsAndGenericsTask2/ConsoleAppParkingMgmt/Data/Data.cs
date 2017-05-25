using System.Collections.Generic;
using ConsoleAppParkingMgmt.Classes;
using ConsoleAppParkingMgmt.Interfaces;
using ConsoleAppParkingMgmt.VehiclesTypes;

namespace ConsoleAppParkingMgmt.Data
{
    public static class Data
    {
        public static List<Slot<IVehicle>> GetAllSlotsOne()
        {
            var allSlots = new List<Slot<IVehicle>>
                           {
                               new Slot<IVehicle>(1)
                               {
                                   Vehicle = new Car
                                             {
                                                 Name = "Nice Car",
                                                 Engine = 2.0,
                                                 RegNo = 45
                                             }
                               },
                               new Slot<IVehicle>(2)
                               {
                                   Vehicle = null
                               },
                               new Slot<IVehicle>(3)
                               {
                                   Vehicle = new Bus
                                             {
                                                 Name = "Big Bus",
                                                 PeopleCapacity = 30,
                                                 RegNo = 93
                                             }
                               },
                               new Slot<IVehicle>(4)
                               {
                                   Vehicle = null
                               }
                           };
            return allSlots;
        }

        public static List<Slot<IVehicle>> GetAllSlotsTwo()
        {
            var allSlots = new List<Slot<IVehicle>>
                           {
                               new Slot<IVehicle>(1)
                               {
                                   Vehicle = new Car
                                             {
                                                 Name = "Super Car",
                                                 Engine = 4.5,
                                                 RegNo = 007
                                             }
                               },
                               new Slot<IVehicle>(2)
                               {
                                   Vehicle = new Bus
                                             {
                                                 Name = "School Bus",
                                                 PeopleCapacity = 30,
                                                 RegNo = 93
                                             }
                               },
                               new Slot<IVehicle>(3)
                               {
                                   Vehicle = null
                               },
                               new Slot<IVehicle>(4)
                               {
                                   Vehicle = null
                               },
                               new Slot<IVehicle>(6)
                               {
                                   Vehicle = null
                               },

                               new Slot<IVehicle>(5)
                               {
                                   Vehicle = new Truck {Name = "Gas Tanker", LoadCapacity = 4.1, RegNo = 20}
                               }
                           };
            return allSlots;
        }
    }
}