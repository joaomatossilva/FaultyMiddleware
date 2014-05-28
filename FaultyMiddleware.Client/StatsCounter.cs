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
    }
}