using System.Linq;

using Telephony.Exeptions;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {

        public string Model { get; set; }

        public string CallingPhones(string phone)
        {

            if (!phone.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... { phone}";
        }
    }
}
