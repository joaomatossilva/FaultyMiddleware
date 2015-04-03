using System;
using System.Threading;

namespace FaultyMiddleware.FaultyService
{
    public class Service
    {
        private static readonly Random Rand = new Random();

        public string GetMyDate(DateTime dateTime)
        {
            Thread.Sleep(50);
            if (Rand.NextDouble() <= .3)
            {
                throw new Exception("Fault!");
            }
            return string.Format("My date is {0}", dateTime);
        }
    }
}
