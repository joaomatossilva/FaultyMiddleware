using System;
using Ninject.Extensions.Interception;

namespace FaultyMiddleware.Client
{
    public class RetryInterceptor : IInterceptor
    {
        private readonly StatsCounter _counter;
        private const int Tries = 3;

        public RetryInterceptor(StatsCounter counter)
        {
            _counter = counter;
        }

        public void Intercept(IInvocation invocation)
        {
            var tryNumber = 0;
            do
            {
                try
                {
                    invocation.Proceed();
                    return;
                }
                catch (Exception ex)
                {
                    tryNumber++;
                    if (tryNumber == Tries)
                    {
                        throw;
                    }
                }
            } while (true); 
        }
    }
}
