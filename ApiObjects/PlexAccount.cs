using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.PlexAccount
{
   public class PlexAccount
   {
      public MyPlex? MediaContainer { get; set; }
   }

   public class MyPlex
   {
      public string? AuthToken { get; set; }
      public string? Username { get; set; }
      public string? MappingState { get; set; }
      public string? MappingError { get; set; }
      public string? SignInState { get; set; }
      public string? PublicAddress { get; set; }
      public string? PrivatePort { get; set; }
      public string? PrivateAddress { get; set; }
      public string? SubscriptionFeatures { get; set; }
      public bool SubscriptionActive { get; set; }
      public string? SubscriptionState { get; set; }
   }
}
