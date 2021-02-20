using System;
using System.Linq;
using Telephony.Exeptions;

namespace Telephony
{
    public class Smartphone : IStationaryPhone, ISmartphone
    {

        public string Model { get; set; }

        public string BrowsingWeb(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }
            return $"Browsing: {url}!";
        }

        public string CallingPhones(string phone)
        {
            if (!phone.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... { phone}";
        }
    }
}
