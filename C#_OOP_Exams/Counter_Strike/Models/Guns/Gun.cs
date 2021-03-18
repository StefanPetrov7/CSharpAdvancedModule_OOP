using System;
using Counter_Strike.Models.Guns.Contracts;
using Counter_Strike.Utilities.Messages;

namespace Counter_Strike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        // If the setter is private it can set only in this class !!!!.
        // In this task we need to make it protected since the interface has been created only with {get;}.
        // Name can stay with private set sicnce it will be chnaged only from this class.

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }

        }

        // BuletsCount setter need to be protected as it will be changed in the child classes.

        public int BulletsCount
        {
            get { return this.bulletsCount; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletCount);
                }

                this.bulletsCount = value;
            }
        }

        abstract protected int FireRate { get; }  // Property need to be implemented in the child classes with only getter.
                                                  // This is how the Fire method will use each class individual Firerate
        public int Fire()
        {
            if (this.BulletsCount - FireRate >= 0)
            {
                this.BulletsCount -= FireRate;
                return FireRate;
            }
            else
            {
                int reultingBullets = this.BulletsCount;
                this.BulletsCount = 0;
                return reultingBullets;
            }
        }
    }
}
