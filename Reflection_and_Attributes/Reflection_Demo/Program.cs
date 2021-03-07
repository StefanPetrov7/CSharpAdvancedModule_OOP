using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Reflection_Demo
{
    class Program
    {

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        static void Main(string[] args)
        {

            SetCursorPos(0, 0);

            //Car car = new Car();
            //car.name = "Mercedes";
            //Type type = car.GetType();
            //Type type2 = typeof(Car);
            //Type type3 = Type.GetType("Reflection_Demo.Car");

            //var obj = Activator.CreateInstance(type)as Car;
           

            //var intTypes = typeof(int).Assembly.GetTypes();

            //var types = Assembly.GetExecutingAssembly().GetTypes();

            //foreach (var item in intTypes)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }

    public class Car
    {
        public string name;

        public int Year { get; set; }

        public void Move()
        {

        }
    }

    public class Truck
    {
        public string name;

        public int Weight { get; set; }

        public void Stop()
        {

        }
    }
}
