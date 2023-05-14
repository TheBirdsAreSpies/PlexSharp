using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.Preferences
{
   public class Preferences
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   public class Setting
   {
      public string? Id { get; set; }
      public string? Label { get; set; }
      public string? Summary { get; set; }
      public string? Type { get; set; }
      public string? Default { get; set; }
      public string? Value { get; set; }
      public bool Hidden { get; set; }
      public bool Advanced { get; set; }
      public string? Group { get; set; }
      public string? EnumValues { get; set; }
   }

   public class MediaContainer
   {
      public int Size { get; set; }
      public List<Setting>? Setting { get; set; }
   }
}
