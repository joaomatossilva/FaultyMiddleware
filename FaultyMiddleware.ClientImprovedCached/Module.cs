using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace FaultyMiddleware.Client
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<StatsCounter>().ToConstant(new StatsCounter());
            Kernel.Bind<PoorMansCacheProvider>().ToConstant(new PoorMansCacheProvider());
            var binding = Kernel.Bind<INaiveClient>().To<NaiveClient>();
            binding.Intercept().With<CacheInterceptor>().InOrder(1);
            binding.Intercept().With<RetryInterceptor>().InOrder(2);
        }
    }
}
