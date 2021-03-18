using System;
using Counter_Strike.Models.Players.Contracts;
using Counter_Strike.Utilities.Messages;

namespace Counter_Strike.Repositories
{
    public class PlayerRepository : Repository<IPlayer>
    {
        protected override Func<IPlayer, bool> FindByNameDeligate(string name)
        {
            return x => x.Username == name;
        }

        protected override string GetNullModelValidationMessage()
        {
            return ExceptionMessages.InvalidplayerRepository;
        }
    }
}
