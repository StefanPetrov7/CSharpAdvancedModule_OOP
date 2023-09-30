using PersonInfo.Contracts;
namespace PersonInfo.Models
{
	public class Smartphone : ICalling, IBrowsing
	{
        public Smartphone() { }

        public string Browese(string site) => $"Browsing: {site}!";

        public string Call(string phone) => $"Calling... {phone}";
    
    }
}

