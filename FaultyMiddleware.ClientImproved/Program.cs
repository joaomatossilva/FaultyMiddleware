using System;
using Ninject;

namespace FaultyMiddleware.Client
{
    class Program
    {
        const int TimesToInvoke = 1000;

        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(new Module());

            var counter = kernel.Get<StatsCounter>();
            var client = kernel.Get<INaiveClient>();
            counter.Stopwatch.Start();
            for (var i = 0; i < TimesToInvoke; i++)
            {
                try
                {
                    client.GetMyDate(DateTime.Today.AddDays(i % 30));
                    counter.TotalSuccess++;
                }
                catch (Exception ex)
                {
                    counter.TotalError++;
                }
            }
            counter.Stopwatch.Stop();

            counter.PrintStats();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
