using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.Exceptions
{
   internal class NotAuthorizedException : Exception
   {
      public NotAuthorizedException(string message) : base(message)
      { }
   }
}
