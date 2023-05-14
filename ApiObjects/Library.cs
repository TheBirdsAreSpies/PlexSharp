using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.Library
{
   [Newtonsoft.Json.JsonObject(Id = "")]
   public class Library
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   public class Directory
   {
      public string? Key { get; set; }
      public string? Title { get; set; }
   }

   public class MediaContainer
   {
      public int Size { get; set; }
      public bool AllowSync { get; set; }
      public string? Art { get; set; }
      public string? Content { get; set; }
      public string? Identifier { get; set; }
      public string? MediaTagPrefix { get; set; }
      public int MediaTagVersion { get; set; }
      public string? Title1 { get; set; }
      public string? Title2 { get; set; }
      public List<Directory>? Directory { get; set; }
   }
}
