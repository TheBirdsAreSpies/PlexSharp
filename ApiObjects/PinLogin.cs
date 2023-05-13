using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects
{
   [Newtonsoft.Json.JsonObject(Id = "")]
   internal class PinLogin
   {
      public int Id { get; set; }
      public string? Code { get; set; }
      public string? Product { get; set; }
      public bool Trusted { get; set; }
      public string? Qr { get; set; }
      public string? ClientIdentifier { get; set; }
      public Location? Location { get; set; }
      public int ExpiresIn { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime ExpiresAt { get; set; }
      public object? AuthToken { get; set; }
      public object? NewRegistration { get; set; }
   }

   public class Location
   {
      public string? Code { get; set; }
      public bool EuropeanUnionMember { get; set; }
      public string? ContinentCode { get; set; }
      public string? Country { get; set; }
      public string? City { get; set; }
      public string? TimeZone { get; set; }
      public string? PostalCode { get; set; }
      public bool InPrivacyRestrictedCountry { get; set; }
      public string? Subdivisions { get; set; }
      public string? Coordinates { get; set; }
   }
}
