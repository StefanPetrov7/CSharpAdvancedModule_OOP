using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle viechele = new Vehicle(10, 100);
            Motorcycle motorcycle = new Motorcycle(10, 100);
            Car car = new Car(10, 100);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(10, 100);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(10, 100);
            SportCar  sportcar= new SportCar(10, 100);
            FamilyCar familyCar = new FamilyCar(10, 100);
            viechele.Drive(10);
            car.Drive(10);
            motorcycle.Drive(10);
            raceMotorcycle.Drive(10);
            crossMotorcycle.Drive(10);
            familyCar.Drive(10);
            sportcar.Drive(10);
            Console.WriteLine();
        }
    }
}

