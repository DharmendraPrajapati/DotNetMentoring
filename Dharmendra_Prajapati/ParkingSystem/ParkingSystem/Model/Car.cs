namespace ParkingSystem.Model
{
    public class Car<T>
    {
        public string Owner { get; set; }
        public T Manufecturer { get; set; }
    }
}
