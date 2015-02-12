
using NServiceBus.Persistence;

namespace PublishingServer
{
    using NServiceBus;
   
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
           //configuration.UsePersistence<InMemoryPersistence>();
            configuration.UsePersistence<RavenDBPersistence>().For(
                Storage.Sagas,
                Storage.Timeouts,
                Storage.Subscriptions);
        }
    }
}
