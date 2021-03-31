using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;

namespace CosmosX.Entities.Reactors.Factories.Contracts
{
    public interface IReactorFactory
    {
        IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter);
    }
}
