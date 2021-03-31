using System;
using System.Linq;
using System.Reflection;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.Factories.Contracts;

namespace CosmosX.Entities.Reactors.Factories
{
    public class ReactorFactory : IReactorFactory
    {
        private const string reactorSufix = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            reactorTypeName += reactorSufix;
            Type reactorType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == reactorTypeName);
            object[] ctorParams = new object[]{id, moduleContainer, additionalParameter};
            IReactor reactor = (IReactor)Activator.CreateInstance(reactorType, ctorParams);
            return reactor;
        }

    }
}
