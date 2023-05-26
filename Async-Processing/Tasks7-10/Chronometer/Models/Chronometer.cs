using Chronometer.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer.Models
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;
        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }
        public string GetTime
        {
            get
            {
                return stopwatch.Elapsed.ToString(@"mm\:ss\:ffff");
            }
        }


        public List<string> Laps { get { return laps; } }

        public string Lap()
        {
            string timestamp = GetTime;
            laps.Add(timestamp);
            return timestamp;
        }

        public void Reset()
        {
            stopwatch.Stop();
            stopwatch = new Stopwatch();
            laps = new List<string>();

        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();    
        }
    }
}
