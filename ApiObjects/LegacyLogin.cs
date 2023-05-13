using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects
{
   public class LegacyLogin
   {
      public User? user { get; set; } = null;
   }

   public class User
   {
      public int id { get; set; }
      public string? uuid { get; set; }
      public string? email { get; set; }
      public DateTime joined_at { get; set; }
      public string? username { get; set; }
      public string? title { get; set; }
      public string? thumb { get; set; }
      public bool hasPassword { get; set; }
      public string? authToken { get; set; }
      public string? authentication_token { get; set; }
      public Subscription? subscription { get; set; }
      public Roles? roles { get; set; }
      public string[]? entitlements { get; set; }
      public DateTime confirmedAt { get; set; }
      public object? forumId { get; set; }
      public bool rememberMe { get; set; }
   }

   public class Subscription
   {
      public bool active { get; set; }
      public string? status { get; set; }
      public string? plan { get; set; }
      public string[]? features { get; set; }
   }

   public class Roles
   {
      public string[]? roles { get; set; }
   }
}
