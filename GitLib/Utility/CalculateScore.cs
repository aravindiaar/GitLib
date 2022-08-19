using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLib.Utility;

namespace GitLib.Utility
{
    class CalculateScore
    {
        public static int Cal(List<DateTime> Data)
        {
            var c = Data.Count();

            for (int i = 1; i < Data.Count; i++)
            {
                var First = Data[i - 1];
                var Second = Data[i];
                TimeSpan span = First.Subtract(Second);
                var x= span.TotalMinutes;
                if (x < AllCmds.TIME_INTERVAL)
                {
                    c--;
                }
            }
            int percentComplete = (int)Math.Round((double)(100 * c) / Data.Count());
            return percentComplete;
        }
    }
}
