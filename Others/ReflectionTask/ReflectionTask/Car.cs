namespace ReflectionTask
{
    public class Car : Vehicle<Car>
    {
        public Car(int noOfDoors)
        {
            NoOfDoors = noOfDoors;
        }

        public int NoOfDoors { get; set; }
    }
}