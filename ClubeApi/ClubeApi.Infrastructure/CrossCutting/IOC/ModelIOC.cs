using Autofac;

namespace ClubeApi.Infrastructure.CrossCutting.IOC
{
    public class ModelIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }
    }
}
