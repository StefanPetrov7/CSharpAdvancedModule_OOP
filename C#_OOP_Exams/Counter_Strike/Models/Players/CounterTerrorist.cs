using Counter_Strike.Models.Guns.Contracts;

namespace Counter_Strike.Models.Players
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string username, int health, int arrmor, IGun gun)
            : base( username,  health,  arrmor,  gun)
        {
        }
    }
}
