using System;

namespace ReflectionTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var listOfCars = ListUtility.CreateList<Vehicle<Car>>();
            var listOfBikes = ListUtility.CreateList<Bike>();
            listOfCars.Add(new Vehicle<Car>());
            listOfCars.Add(new Vehicle<Car>());
            listOfCars.Add(new Vehicle<Car>());
            listOfBikes.Add(new Bike());
            listOfBikes.Add(new Bike());
            listOfBikes.Add(new Bike());
            listOfBikes.Add(new Bike());
            foreach (var car in listOfCars)
            {
                Console.WriteLine(car.GetType());
            }
            foreach (var bike in listOfBikes)
            {
                Console.WriteLine(bike.GetType());
            }
            Console.ReadKey();
        }
    }
}