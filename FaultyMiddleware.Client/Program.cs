using System;

namespace FaultyMiddleware.Client
{
    class Program
    {
        const int TimesToInvoke = 1000;

        static void Main(string[] args)
        {
            var counter = new StatsCounter();
            var client = new NaiveClient(counter);
            counter.Stopwatch.Start();
            for (var i = 0; i < TimesToInvoke; i++)
            {
                try
                {
                    client.GetMyDate(DateTime.Today.AddDays(i%30));
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
