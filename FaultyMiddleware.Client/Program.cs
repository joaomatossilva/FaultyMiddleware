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

            Console.WriteLine("Execution Time: {0} seconds", counter.Stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine("Total Executions: {0}", counter.TotalExecutions);
            Console.WriteLine("Execution Sucess: {0}", counter.ExecutionSuccess);
            Console.WriteLine("Total Sucess: {0}", counter.TotalSuccess);
            Console.WriteLine("Execution Fail: {0}", counter.ExecutionError);
            Console.WriteLine("Total Fail: {0}", counter.TotalError);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
