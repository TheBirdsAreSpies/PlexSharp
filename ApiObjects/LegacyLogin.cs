using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects
{
   public class LegacyLogin
   {
      public User? User { get; set; } = null;
   }

   public class User
   {
      public int Id { get; set; }
      public string? Uuid { get; set; }
      public string? Email { get; set; }
      [Newtonsoft.Json.JsonProperty(PropertyName = "joined_at")]
      public DateTime JoinedAt { get; set; }
      public string? Username { get; set; }
      public string? Title { get; set; }
      public string? Thumb { get; set; }
      public bool HasPassword { get; set; }
      public string? AuthToken { get; set; }
      [Newtonsoft.Json.JsonProperty(PropertyName = "authentication_token")]
      public string? AuthenticationToken { get; set; }
      public Subscription? Subscription { get; set; }
      public RolesType? Roles { get; set; }
      public string[]? Entitlements { get; set; }
      public DateTime ConfirmedAt { get; set; }
      public object? ForumId { get; set; }
      public bool RememberMe { get; set; }
   }

   public class Subscription
   {
      public bool Active { get; set; }
      public string? Status { get; set; }
      public string? Plan { get; set; }
      public string[]? Features { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "Roles")]
   public class RolesType
   {
      public string[]? Roles { get; set; }
   }
}
