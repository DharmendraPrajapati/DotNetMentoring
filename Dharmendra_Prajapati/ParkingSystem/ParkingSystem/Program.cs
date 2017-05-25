using ParkingSystem.Model;
using ParkingSystem.Services;
using System;
using System.Collections.Generic;

namespace ParkingSystem
{
    //TODO: I think you slightly missed the idea of the task. Its a geenral parking system not different different parking system for different cars.
    //TODO: Moreover I do not see a reason for making Parking Slot/Floor/Parking System classes to be generic
    internal class Program
    {
        private const int ParkingCapacity = 16;
        internal static void Main(string[] args)
        {
            var audiCarParking = new ParkingServices<Audi>(GetAudiParking());
            Console.WriteLine("All Avaialble Slots :" + audiCarParking.GetAllAvailableSlots() + " / All Parking Slots :" + audiCarParking.GetAllSlots());
            Console.WriteLine("\n\n Presss (1) for Add Car or (2) for remove car in parking ");
            var key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    {
                        var car = new Car<Audi>();
                        var audiinfo = new Audi();
                        Console.WriteLine("Enter Car details for audi \n Manufecture Year ");
                        audiinfo.ManufectureYear = Console.ReadLine();
                        Console.WriteLine("Owner");
                        car.Owner = Console.ReadLine();
                        Console.WriteLine("Model ");
                        audiinfo.Model = Console.ReadLine();
                        Console.WriteLine("Price ");
                        audiinfo.Price = Console.ReadLine();
                        car.Manufecturer = audiinfo;

                        audiCarParking.AddCar(car);
                        Console.WriteLine("\n\n All Avaialble Slots :" + audiCarParking.GetAllAvailableSlots() + " / All Parking Slots :" + audiCarParking.GetAllSlots());
                        break;
                    }
                case "2":
                    {

                        Console.WriteLine("Enter Parking Details details for audi \n Floor Number");
                        var floorNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Slot Number ");
                        var slotNum = Convert.ToInt32(Console.ReadLine());
                        audiCarParking.RemoveCar(floorNum, slotNum);
                        Console.WriteLine("\n\n All Avaialble Slots :" + audiCarParking.GetAllAvailableSlots() + " / All Parking Slots :" + audiCarParking.GetAllSlots());
                        break;
                    }
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }

            Console.ReadKey();
        }
        private static ParkingSystem<Audi> GetAudiParking()
        {
            var parkingObj = new ParkingSystem<Audi>
            {
                ManagerName = "Audi Parking",
                Floors = new List<Floors<Audi>>
                {
                    new Floors<Audi>
                    {
                        FloorNumber = 1,
                        ParkingSlots = GetAudiParkingSlots("A1"),
                        Capacity = ParkingCapacity
                    },
                    new Floors<Audi>
                    {
                        FloorNumber = 2,
                        ParkingSlots = GetAudiParkingSlots("A2"),
                        Capacity = ParkingCapacity
                    }
                }
            };
            return parkingObj;
        }
        private static ParkingSystem<Bmw> GetBmwParking()
        {
            var parkingObj = new ParkingSystem<Bmw>
            {
                ManagerName = "Bmw Parking",
                Floors = new List<Floors<Bmw>>
                {
                    new Floors<Bmw>
                    {
                        FloorNumber = 1,
                        ParkingSlots = GetBmwParkingSlots("B1"),
                        Capacity = ParkingCapacity
                    },
                    new Floors<Bmw>
                    {
                        FloorNumber = 2,
                        ParkingSlots = GetBmwParkingSlots("B2"),
                        Capacity = ParkingCapacity
                    }
                }
            };
            return parkingObj;
        }
        private static IList<ParkingSlots<Audi>> GetAudiParkingSlots(string floorNum)
        {
            return new List<ParkingSlots<Audi>>
                        {
                            new ParkingSlots<Audi>
                            {

                                Car = new Car<Audi>
                                {
                                    Manufecturer = new Audi { ManufectureYear = "2014" ,Model="A3 - "+floorNum,Price = "$25000" },
                                    Owner = "Abhinav"
                                },
                                IsAvailable = false,
                                SlotNumber = 1
                            },
                            new ParkingSlots<Audi>
                            {
                                Car = new Car<Audi>
                                {
                                    Manufecturer = new Audi { ManufectureYear = "2012" ,Model="A4 - "+floorNum,Price = "$35000" },
                                    Owner = "Jim"
                                },
                                IsAvailable = false,
                                SlotNumber = 2
                            }
                        };
        }
        private static IList<ParkingSlots<Bmw>> GetBmwParkingSlots(string floorNum)
        {
            return new List<ParkingSlots<Bmw>>
                        {
                            new ParkingSlots<Bmw>
                            {
                                Car = new Car<Bmw>
                                {
                                    Manufecturer = new Bmw { Year = "2014" ,Model="B3 - "+floorNum,Price = "$25000" },
                                    Owner = "John"
                                },
                                IsAvailable = false,
                                SlotNumber = 1
                            },
                            new ParkingSlots<Bmw>
                            {
                                Car = new Car<Bmw>
                                {
                                    Manufecturer = new Bmw { Year = "2012" , Model="B5 - "+floorNum,Price = "$35000" },
                                    Owner = "Smith"
                                },
                                IsAvailable = false,
                                SlotNumber = 2
                            }
                        };
        }

    }
}
