using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.MediaFile
{
   // Part: -HasThumbnail, -Decision, -Selected, -Stream
   // Genre, Country, Collection, Director, Writer, Role: Has only tag

   [Newtonsoft.Json.JsonObject(Id = "")]
   public class MediaFile
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   public class MediaContainer : CurrentlyPlaying.MediaContainer
   {
      public new List<Metadata>? Metadata { get; set; }
      public string? Identifier { get; set; }
      public string? MediaTagPrefix { get; set; }
      public int MediaTagVersion { get; set; }
      public List<Provider>? Provider { get; set; }

   }

   public class Metadata : CurrentlyPlaying.Metadata
   {
      public bool AllowSync { get; set; }
      public string? LibrarySectionUUID { get; set; }
      public bool Personal { get; set; }
      public string? SourceTitle { get; set; }
      public int ViewCount { get; set; }

      public int lastViewedAt { private get; set; }
      public DateTime LastViewedAt {
         get { return Utils.ConvertEpochTime(lastViewedAt); }
         private set { }
      }

      // TV Show
      public string? ParentRatingKey { get; set; }
      public string? GrandparentRatingKey { get; set; }
      public string? GrandparentKey { get; set; }
      public string? ParentKey { get; set; }
      public string? GrandparentTitle { get; set; }
      public string? ParentTitle { get; set; }
      public int Index { get; set; }
      public int ParentIndex { get; set; }
      public string? ParentThumb { get; set; }
      public string? GrandparentThumb { get; set; }
      public string? GrandparentArt { get; set; }
      public string? GrandparentTheme { get; set; }


   }

   public class Provider
   {
      public string? Key { get; set; }
      public string? Title { get; set; }
      public string? Type { get; set; }
   }
}
