using WildFarm.Enumeration;
using WildFarm.Models;
using WildFarm.Exceptios;
using WildFarm.Common;

namespace WildFarm.Factory
{
    public static class AnimalFactory
    {
        public static Animal GetAnimal(string[] data)
        {
            Animal animal = null;
            string animalType = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            if (EnumParse(animalType) == AnimalType.Cat)
            {
                animal = new Cat(name, weight, data[3], data[4]);
            }
            else if (EnumParse(animalType) == AnimalType.Dog)
            {
                animal = new Dog(name, weight, data[3]);
            }
            else if (EnumParse(animalType) == AnimalType.Mouse)
            {
                animal = new Mouse(name, weight, data[3]);
            }
            else if (EnumParse(animalType) == AnimalType.Hen)
            {
                animal = new Hen(name, weight, double.Parse(data[3]));
            }
            else if (EnumParse(animalType) == AnimalType.Owl)
            {
                animal = new Owl(name, weight, double.Parse(data[3]));
            }
            else if (EnumParse(animalType) == AnimalType.Tiger)
            {
                animal = new Tiger(name, weight, data[3], data[4]);
            }

            return animal;

        }

        private static AnimalType EnumParse(string animalType)
        {
            if (Enum.TryParse<AnimalType>(animalType, out AnimalType curType))
            {
                return curType;
            }
            else
            {
                throw new InvalidAnimal(GlobConst.INVALID_ANIMAL);
            }
        }
    }
}

