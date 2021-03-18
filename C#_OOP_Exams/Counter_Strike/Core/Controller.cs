using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Counter_Strike.Core.Contracts;
using Counter_Strike.Models.Guns.Contracts;
using Counter_Strike.Models.Maps;
using Counter_Strike.Models.Maps.Contracts;
using Counter_Strike.Models.Players;
using Counter_Strike.Models.Players.Contracts;
using Counter_Strike.Repositories;
using Counter_Strike.Repositories.Contracts;
using Counter_Strike.Utilities.Messages;

namespace Counter_Strike.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> gunRepository;
        private IRepository<IPlayer> playerRepository;
        private IMap map;

        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;   // Reflection.
            Type gunType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (gunType == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            var @params = new object[] {name,bulletsCount };
            gun = (IGun)Activator.CreateInstance(gunType, @params);
            this.gunRepository.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);


            //IGun gun;   // No Reflection.
            //if (type == typeof(Rifle).Name)
            //{
            //    gun = new Rifle(name, bulletsCount);
            //}
            //else if (type == typeof(Pistol).Name)
            //{
            //    gun = new Pistol(name, bulletsCount);
            //}
            //else
            //{
            //    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            //}

            //this.gunRepository.Add(gun);

            //return string.Format(OutputMessages.SuccessfullyAddedGun, name);


            //try    // => Reflection, this may have Exception message mistakes !!!!.
            //{
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    Type gunType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
            //    object[] args = new object[] { name, bulletsCount };
            //    IGun gun = (Gun)Activator.CreateInstance(gunType, args);
            //    this.gunRepository.Add(gun);
            //    return string.Format(OutputMessages.SuccessfullyAddedGun, name);
            //}
            //catch (Exception)
            //{
            //    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            //}

        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {

            IGun gun = this.gunRepository.FindByName(gunName);  // No Reflection

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player;

            if (type == typeof(Terrorist).Name)
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == typeof(CounterTerrorist).Name)
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidplayerType);
            }

            this.playerRepository.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);


            //try   // => Reflection, this may have Exception message mistakes !!!!.
            //{
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    Type playerType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
            //    object[] args = new object[] { username, health, armor, gun };
            //    IPlayer player = (Player)Activator.CreateInstance(playerType, args);
            //    this.playerRepository.Add(player);
            //    return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            //}
            //catch (Exception)
            //{
            //    throw new ArgumentException(ExceptionMessages.InvalidplayerType);
            //}

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.playerRepository.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            return this.map.Strat(this.playerRepository.Models.ToList());
        }
    }
}
