using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace FaultyMiddleware.Client
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<StatsCounter>().ToConstant(new StatsCounter());
            Kernel.Bind<INaiveClient>().To<NaiveClient>().Intercept().With<RetryInterceptor>();
        }
    }
}
