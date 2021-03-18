namespace Counter_Strike.Models.Guns
{
    public class Rifle : Gun
    {

        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        protected override int FireRate => 10;

    }
}
