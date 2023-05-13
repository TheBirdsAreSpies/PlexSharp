using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects
{
   public class History
   {
      public MediaContainerHistory? MediaContainer { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "Metadata")]
   public class MetadataHistory
   {
      public string? historyKey { get; set; }
      public string? key { get; set; }
      public string? ratingKey { get; set; }
      public string? librarySectionID { get; set; }
      public string? title { get; set; }
      public string? type { get; set; }
      public string? thumb { get; set; }
      
      [Newtonsoft.Json.JsonProperty(PropertyName = "viewedAt")]
      public long viewedAtInternally { private get; set; }

      public DateTime ViewedAt
      {
         get { return Utils.ConvertEpochTime(viewedAtInternally); }
         private set { }
      }

      public int accountID { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "MediaContainer")]
   public class MediaContainerHistory
   {
      public int size { get; set; }
      public List<MetadataHistory>? Metadata { get; set; }
   }
}
