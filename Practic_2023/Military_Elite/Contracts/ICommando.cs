using Military_Elite.Models;
namespace Military_Elite.Contracts
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
}

