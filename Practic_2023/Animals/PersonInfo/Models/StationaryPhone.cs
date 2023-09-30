using PersonInfo.Contracts;
namespace PersonInfo.Models
{
	public class StationaryPhone : ICalling
	{
		public StationaryPhone() { }

        public string Call(string phone) => $"Dialing... {phone}";
    }
}

