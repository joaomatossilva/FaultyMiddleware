using System.Linq;
using Ninject.Extensions.Interception;

namespace FaultyMiddleware.Client
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly PoorMansCacheProvider _cacheProvider;

        public CacheInterceptor(PoorMansCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            var arguments = invocation.Request.Arguments;
            var methodName = invocation.Request.Method.Name;
            // create an identifier for the cache key
            var key = methodName + "_" + string.Join("", arguments.Select(a => a ?? ""));  
            object value;
            if (_cacheProvider.TryGet(key, out value))
            {
                invocation.ReturnValue = value;
                return;
            }
            
            invocation.Proceed();

            _cacheProvider.Set(key, invocation.ReturnValue);
        }
    }
}
