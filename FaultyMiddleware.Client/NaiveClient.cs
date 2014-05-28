using System;
using FaultyMiddleware.FaultyService;

namespace FaultyMiddleware.Client
{
    public interface INaiveClient
    {
        string GetMyDate(DateTime date);
    }

    public class NaiveClient : INaiveClient
    {
        private StatsCounter _counter;

        public NaiveClient(StatsCounter counter)
        {
            _counter = counter;
        }

        public string GetMyDate(DateTime date)
        {
            var faultService = new Service();
            try
            {
                _counter.TotalExecutions++;
                var mydate = faultService.GetMyDate(date);
                _counter.ExecutionSuccess++;
                return mydate;
            }
            catch (Exception)
            {                
                _counter.ExecutionError++;
                throw;
            }
        }
    }
}
