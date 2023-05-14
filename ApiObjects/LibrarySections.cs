using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.LibrarySections
{
   public class LibrarySections
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "Directory")]
   public class DirectoryType
   {
      public bool AllowSync { get; set; }
      public string? Art { get; set; }
      public string? Composite { get; set; }
      public bool Filters { get; set; }
      public bool Refreshing { get; set; }
      public string? Thumb { get; set; }
      public string? Key { get; set; }
      public string? Type { get; set; }
      public string? Title { get; set; }
      public string? Agent { get; set; }
      public string? Scanner { get; set; }
      public string? Language { get; set; }
      public string? Uuid { get; set; }

      public int updatedAt { private get; set; }
      public int createdAt { private get; set; }
      public int scannedAt { private get; set; }
      
      public DateTime UpdatedAt {
         get { return Utils.ConvertEpochTime(updatedAt); }
         private set { }
      }

      public DateTime CreatedAt {
         get { return Utils.ConvertEpochTime(createdAt); }
         private set { }
      }

      public DateTime ScannedAt {
         get { return Utils.ConvertEpochTime(scannedAt); }
         private set { }
      }

      public bool Content { get; set; }
      public bool Directory { get; set; }

      public int contentChangedAt { private get; set; }
      public DateTime ContentChangedAt {
         get { return Utils.ConvertEpochTime(contentChangedAt); }
         private set { }
      }

      public int Hidden { get; set; }
      public List<Location>? Location { get; set; }
   }

   public class MediaContainer
   {
      public int Size { get; set; }
      public bool AllowSync { get; set; }
      public string? Title1 { get; set; }
      public List<DirectoryType>? Directory { get; set; }
   }

   public class RootObject
   {
      public MediaContainer? MediaContainer { get; set; }
   }
}
