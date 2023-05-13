using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp
{
   internal class Utils
   {
      public static DateTime ConvertEpochTime(long epochTime)
      {
         DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(epochTime);
         return offset.LocalDateTime;
      }

      public static TimeSpan ConvertEpochTimeAsTimeSpan(long epochTime)
      {
         return TimeSpan.FromMilliseconds(epochTime);
      }
   }
}
