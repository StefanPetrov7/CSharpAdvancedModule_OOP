using System.Collections.Generic;
using Counter_Strike.Models.Players.Contracts;

namespace Counter_Strike.Models.Maps.Contracts
{
    public interface IMap
    {
        string Strat(ICollection<IPlayer> players);
    }
}
