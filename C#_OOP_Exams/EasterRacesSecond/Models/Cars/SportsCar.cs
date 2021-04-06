namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        private const double cc = 3000;
        private const int minHp = 250;
        private const int maxHp = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cc, minHp, maxHp)
        { }
    }
}
