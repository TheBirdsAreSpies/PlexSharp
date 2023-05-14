using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects.CurrentlyPlaying
{
   // TODO implement Track tag
   // TODO implement Photo tag
   // ref https://github.com/Arcanemagus/plex-api/wiki/Current-Sessions-Status

   [Newtonsoft.Json.JsonObject(Id = "")]
   public class CurrentlyPlaying
   {
      public MediaContainer? MediaContainer { get; set; }
   }

   public class MediaContainer
   {
      public int size { get; set; }
      public List<Metadata>? Metadata { get; set; }
   }

   public class Metadata
   {
      public int addedAt { private get; set; }
      public DateTime AddedAt {
         get { return Utils.ConvertEpochTime(addedAt); }
         private set { }
      }

      public string? Art { get; set; }
      public double AudienceRating { get; set; }
      public string? AudienceRatingImage { get; set; }
      public string? ChapterSource { get; set; }
      public string? ContentRating { get; set; }

      public int duration { private get; set; }
      public TimeSpan Duration {
         get { return Utils.ConvertEpochTimeAsTimeSpan(duration); }
         private set { }
      }

      public string? Guid { get; set; }
      public string? Key { get; set; }
      public string? LibrarySectionID { get; set; }
      public string? LibrarySectionKey { get; set; }
      public string? LibrarySectionTitle { get; set; }
      public string? OriginalTitle { get; set; }
      public string? OriginallyAvailableAt { get; set; }
      public string? RatingKey { get; set; }
      public string? SessionKey { get; set; }
      public string? Studio { get; set; }
      public string? Summary { get; set; }
      public string? Tagline { get; set; }
      public string? Thumb { get; set; }
      public string? Title { get; set; }
      public string? TitleSort { get; set; }
      public string? Type { get; set; }

      public int updatedAt { private get; set; }
      public DateTime UpdatedAt {
         get { return Utils.ConvertEpochTime(updatedAt); }
         private set { }
      }

      public int viewOffset { get; set; }
      public int year { get; set; }
      public List<Media>? Media { get; set; }
      public List<Genre>? Genre { get; set; }
      public List<Country>? Country { get; set; }
      public List<Rating>? Rating { get; set; }
      public List<Collection>? Collection { get; set; }
      public List<Director>? Director { get; set; }
      public List<Writer>? Writer { get; set; }
      public List<RoleType>? Role { get; set; }
      public List<Producer>? Producer { get; set; }
      public SessionUser? User { get; set; }
      public Player? Player { get; set; }
      public Session? Session { get; set; }
   }

   public class Media
   {
      public string? AspectRatio { get; set; }
      public int AudioChannels { get; set; }
      public string? AudioCodec { get; set; }
      public int Bitrate { get; set; }
      public string? Container { get; set; }

      public int duration { private get; set; }
      public TimeSpan Duration {
         get { return Utils.ConvertEpochTimeAsTimeSpan(duration); }
         private set { }
      }

      public int Height { get; set; }
      public string? Id { get; set; }
      public string? VideoCodec { get; set; }
      public string? VideoFrameRate { get; set; }
      public string? VideoProfile { get; set; }
      public string? VideoResolution { get; set; }
      public int Width { get; set; }
      public bool Selected { get; set; }
      public List<Part>? Part { get; set; }
   }

   public class Part
   {
      public string? Container { get; set; }
      public int Duration { get; set; }
      public string? File { get; set; }
      public string? HasThumbnail { get; set; }
      public string? Id { get; set; }
      public string? Key { get; set; }
      public long Size { get; set; }
      public string? VideoProfile { get; set; }
      public string? Decision { get; set; }
      public bool Sselected { get; set; }
      public List<Stream>? Stream { get; set; }
   }

   public class Stream
   {
      // video
      public int BitDepth { get; set; }
      public int Bitrate { get; set; }
      public string? ChromaLocation { get; set; }
      public string? ChromaSubsampling { get; set; }
      public string? Codec { get; set; }
      public int CodedHeight { get; set; }
      public int CodedWidth { get; set; }
      public string? ColorPrimaries { get; set; }
      public string? ColorRange { get; set; }
      public string? ColorSpace { get; set; }
      public string? ColorTrc { get; set; }
      public bool @Default { get; set; }
      public string? DisplayTitle { get; set; }
      public string? ExtendedDisplayTitle { get; set; }
      public double FrameRate { get; set; }
      public int Height { get; set; }
      public string? Id { get; set; }
      public int Index { get; set; }
      public int Level { get; set; }
      public string? Profile { get; set; }
      public int RefFrames { get; set; }
      public int StreamType { get; set; }
      public int Width { get; set; }
      public string? Location { get; set; }

      // audio
      public string? AudioChannelLayout { get; set; }
      public int Channels { get; set; }
      public string? Language { get; set; }
      public string? LanguageCode { get; set; }
      public string? LanguageTag { get; set; }
      public int SamplingRate { get; set; }
      public bool Selected { get; set; }
      public string? Title { get; set; }
   }


   public class Genre
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Tag { get; set; }
   }

   public class Country
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Tag { get; set; }
   }

   public class Rating
   {
      public string? Count { get; set; }
      public string? Image { get; set; }
      public string? Type { get; set; }
      public string? Value { get; set; }
   }

   public class Collection
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Guid { get; set; }
      public string? Id { get; set; }
      public string? Summary { get; set; }
      public string? Tag { get; set; }
   }

   public class Director
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Tag { get; set; }
      public string? TagKey { get; set; }
      public string? Thumb { get; set; }
   }

   public class Writer
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Tag { get; set; }
      public string? TagKey { get; set; }
      public string? Thumb { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "Role")]
   public class RoleType
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Role { get; set; }
      public string? Tag { get; set; }
      public string? TagKey { get; set; }
      public string? Thumb { get; set; }
   }

   public class Producer
   {
      public string? Count { get; set; }
      public string? Filter { get; set; }
      public string? Id { get; set; }
      public string? Tag { get; set; }
      public string? TagKey { get; set; }
      public string? Thumb { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "User")]
   public class SessionUser
   {
      public string? Id { get; set; }
      public string? Thumb { get; set; }
      public string? Title { get; set; }
   }

   public class Player
   {
      public string? Address { get; set; }
      public string? MachineIdentifier { get; set; }
      public string? Model { get; set; }
      public string? Platform { get; set; }
      public string? PlatformVersion { get; set; }
      public string? Product { get; set; }
      public string? Profile { get; set; }
      public string? RemotePublicAddress { get; set; }
      public string? State { get; set; }
      public string? Title { get; set; }
      public string? Version { get; set; }
      public bool Local { get; set; }
      public bool Relayed { get; set; }
      public bool Secure { get; set; }
      public int UserID { get; set; }
   }

   public class Session
   {
      public string? Id { get; set; }
      public int Bandwidth { get; set; }
      public string? Location { get; set; }
   }
}