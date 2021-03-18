using System;
using System.Text;
using Counter_Strike.Models.Guns.Contracts;
using Counter_Strike.Models.Players.Contracts;
using Counter_Strike.Utilities.Messages;

namespace Counter_Strike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int arrmor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidplayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this.gun = value;
            }
        }

        public bool isAlive // => this.Health > 0;
        {
            get { return this.Health > 0; }
        }

        public void TakeDamage(int points)
        {
            //if (points < this.Armor)   // Same algorithm.
            //{
            //    points -= this.Armor;
            //    this.Armor = 0;
            //    this.Health -= points;
            //}
            //else
            //{
            //    this.Armor -= points;
            //}

            if (this.armor - points >= 0)
            {
                this.armor -= points;
                return;
            }
            else if (this.armor > 0)
            {
                points -= this.armor;
                this.Armor = 0;
            }

            this.health -= points;

            if (this.health < 0)
            {
                this.health = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}
