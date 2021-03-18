using Counter_Strike.Models.Guns.Contracts;

namespace Counter_Strike.Models.Players.Contracts
{
    public interface IPlayer
    {
        string Username { get; }

        int Health { get; }

        int Armor { get; }

        IGun Gun { get; }

        bool isAlive { get;  }

        void TakeDamage(int points);
    }
}
