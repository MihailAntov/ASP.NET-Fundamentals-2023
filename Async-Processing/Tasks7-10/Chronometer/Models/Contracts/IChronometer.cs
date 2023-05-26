using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer.Models.Contracts
{
    public interface IChronometer
    {
        string GetTime { get; }
        List<String> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();

    }
}
