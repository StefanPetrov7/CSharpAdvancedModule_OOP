using Military_Elite.Models;
namespace Military_Elite.Contracts
{
	public interface IEngineer
	{
		 IReadOnlyCollection<Repair> Repairs { get; }
	}
}

