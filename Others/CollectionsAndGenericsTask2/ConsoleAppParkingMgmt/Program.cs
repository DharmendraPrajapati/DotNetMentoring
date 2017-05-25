using ConsoleAppParkingMgmt.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppParkingMgmt
{
    internal class Program
    {
        private static void Main()
        {
            var parkingSlots = new List<ParkingSlot>
                                                    {
                                                        new ParkingSlot(Data.Data.GetAllSlotsOne())
                                                        {
                                                            Loaction = "A1"                                            
                                                        },
                                                        new ParkingSlot( Data.Data.GetAllSlotsTwo())
                                                        {
                                                            Loaction = "B2"  
                                                        }
                                                    };
            var floors = new List<Floor>
                                        {
                                            new Floor(parkingSlots)
                                            {
                                                FloorNo = 1,
                                                FloorLocation = "South ",
                                                ParkingSlots = parkingSlots.ToList()
                                            }
                                        };
            var parkingSystem = new ParkingSystem(floors)
                                {
                                    Name = "Grand Parking System ",
                                    ParkingSystemLocation = "EPAM, Hyderabad, India ",
                                    Floors = floors.ToList()
                                };


            Console.WriteLine(parkingSystem.ToString());
            Console.Read();
        }
    }
}