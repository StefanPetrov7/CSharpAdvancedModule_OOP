using System;

using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factory
{
    public class ViechleFactory
    {

        public Viechle ProduceViechle(string type, double fuelQty, double fuelConsumption, double tankCapacity)
        {
            Viechle viechle = null;

            if (type == ViechlesTypes.CAR)
            {
                viechle = new Car(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == ViechlesTypes.Truck)
            {
                viechle = new Truck(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == ViechlesTypes.Bus)
            {
                viechle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }

            if (viechle == null)
            {
                throw new Exception(ExceptionMessages.InvalideViechle);
            }

            return viechle;
        }
    }
}
