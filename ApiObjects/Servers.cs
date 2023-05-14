using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.Servers
{
   public class Servers
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   public class Server
   {
      public string? Name { get; set; }
      public string? Host { get; set; }
      public string? Address { get; set; }
      public int Port { get; set; }
      public string? MachineIdentifier { get; set; }
      public string? Version { get; set; }
   }

   public class MediaContainer
   {
      public int Size { get; set; }
      public List<Server>? Server { get; set; }
   }
}
