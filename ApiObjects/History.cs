﻿using System;
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
      public string? HistoryKey { get; set; }
      public string? Key { get; set; }
      public string? RatingKey { get; set; }
      public string? LibrarySectionID { get; set; }
      public string? Title { get; set; }
      public string? Type { get; set; }
      public string? Thumb { get; set; }
      
      [Newtonsoft.Json.JsonProperty(PropertyName = "viewedAt")]
      public long viewedAtInternally { private get; set; }

      public DateTime ViewedAt
      {
         get { return Utils.ConvertEpochTime(viewedAtInternally); }
         private set { }
      }

      public int AccountID { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "MediaContainer")]
   public class MediaContainerHistory
   {
      public int Size { get; set; }
      public List<MetadataHistory>? Metadata { get; set; }
   }
}
