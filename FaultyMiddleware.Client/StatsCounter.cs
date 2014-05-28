using System;
using System.Diagnostics;

namespace FaultyMiddleware.Client
{
    public class StatsCounter
    {
        public StatsCounter()
        {
            Stopwatch = new Stopwatch();
        }

        public Stopwatch Stopwatch { get; private set; }
        public int TotalExecutions { get; set; }
        public int ExecutionSuccess { get; set; }
        public int ExecutionError { get; set; }
        public int TotalSuccess { get; set; }
        public int TotalError { get; set; }

        public void PrintStats()
        {
            Console.WriteLine("Execution Time: {0} seconds", Stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine("Total Executions: {0}", TotalExecutions);
            Console.WriteLine("Execution Sucess: {0}", ExecutionSuccess);
            Console.WriteLine("Total Sucess: {0}", TotalSuccess);
            Console.WriteLine("Execution Fail: {0}", ExecutionError);
            Console.WriteLine("Total Fail: {0}", TotalError);
        }
    }
}