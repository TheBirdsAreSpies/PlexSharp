using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexSharp.ApiObjects
{
   // TODO implement Track tag
   // TODO implement Photo tag
   // ref https://github.com/Arcanemagus/plex-api/wiki/Current-Sessions-Status

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

      public string? art { get; set; }
      public double audienceRating { get; set; }
      public string? audienceRatingImage { get; set; }
      public string? chapterSource { get; set; }
      public string? contentRating { get; set; }

      public int duration { private get; set; }
      public TimeSpan Duration {
         get { return Utils.ConvertEpochTimeAsTimeSpan(duration); }
         private set { }
      }

      public string? guid { get; set; }
      public string? key { get; set; }
      public string? librarySectionID { get; set; }
      public string? librarySectionKey { get; set; }
      public string? librarySectionTitle { get; set; }
      public string? originalTitle { get; set; }
      public string? originallyAvailableAt { get; set; }
      public string? ratingKey { get; set; }
      public string? sessionKey { get; set; }
      public string? studio { get; set; }
      public string? summary { get; set; }
      public string? tagline { get; set; }
      public string? thumb { get; set; }
      public string? title { get; set; }
      public string? titleSort { get; set; }
      public string? type { get; set; }

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
      public List<Role>? Role { get; set; }
      public List<Producer>? Producer { get; set; }
      public SessionUser? User { get; set; }
      public Player? Player { get; set; }
      public Session? Session { get; set; }
   }

   public class Media
   {
      public string? aspectRatio { get; set; }
      public int audioChannels { get; set; }
      public string? audioCodec { get; set; }
      public int bitrate { get; set; }
      public string? container { get; set; }

      public int duration { private get; set; }
      public TimeSpan Duration {
         get { return Utils.ConvertEpochTimeAsTimeSpan(duration); }
         private set { }
      }

      public int height { get; set; }
      public string? id { get; set; }
      public string? videoCodec { get; set; }
      public string? videoFrameRate { get; set; }
      public string? videoProfile { get; set; }
      public string? videoResolution { get; set; }
      public int width { get; set; }
      public bool selected { get; set; }
      public List<Part>? Part { get; set; }
   }

   public class Part
   {
      public string? container { get; set; }
      public int duration { get; set; }
      public string? file { get; set; }
      public string? hasThumbnail { get; set; }
      public string? id { get; set; }
      public string? key { get; set; }
      public long size { get; set; }
      public string? videoProfile { get; set; }
      public string? decision { get; set; }
      public bool selected { get; set; }
      public List<Stream>? Stream { get; set; }
   }

   public class Stream
   {
      // video
      public int bitDepth { get; set; }
      public int bitrate { get; set; }
      public string? chromaLocation { get; set; }
      public string? chromaSubsampling { get; set; }
      public string? codec { get; set; }
      public int codedHeight { get; set; }
      public int codedWidth { get; set; }
      public string? colorPrimaries { get; set; }
      public string? colorRange { get; set; }
      public string? colorSpace { get; set; }
      public string? colorTrc { get; set; }
      public bool @default { get; set; }
      public string? displayTitle { get; set; }
      public string? extendedDisplayTitle { get; set; }
      public double frameRate { get; set; }
      public int height { get; set; }
      public string? id { get; set; }
      public int index { get; set; }
      public int level { get; set; }
      public string? profile { get; set; }
      public int refFrames { get; set; }
      public int streamType { get; set; }
      public int width { get; set; }
      public string? location { get; set; }

      // audio
      public string? audioChannelLayout { get; set; }
      public int channels { get; set; }
      public string? language { get; set; }
      public string? languageCode { get; set; }
      public string? languageTag { get; set; }
      public int samplingRate { get; set; }
      public bool selected { get; set; }
      public string? title { get; set; }
   }


   public class Genre
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? tag { get; set; }
   }

   public class Country
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? tag { get; set; }
   }

   public class Rating
   {
      public string? count { get; set; }
      public string? image { get; set; }
      public string? type { get; set; }
      public string? value { get; set; }
   }

   public class Collection
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? guid { get; set; }
      public string? id { get; set; }
      public string? summary { get; set; }
      public string? tag { get; set; }
   }

   public class Director
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? tag { get; set; }
      public string? tagKey { get; set; }
      public string? thumb { get; set; }
   }

   public class Writer
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? tag { get; set; }
      public string? tagKey { get; set; }
      public string? thumb { get; set; }
   }

   public class Role
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? role { get; set; }
      public string? tag { get; set; }
      public string? tagKey { get; set; }
      public string? thumb { get; set; }
   }

   public class Producer
   {
      public string? count { get; set; }
      public string? filter { get; set; }
      public string? id { get; set; }
      public string? tag { get; set; }
      public string? tagKey { get; set; }
      public string? thumb { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "User")]
   public class SessionUser
   {
      public string? id { get; set; }
      public string? thumb { get; set; }
      public string? title { get; set; }
   }

   public class Player
   {
      public string? address { get; set; }
      public string? machineIdentifier { get; set; }
      public string? model { get; set; }
      public string? platform { get; set; }
      public string? platformVersion { get; set; }
      public string? product { get; set; }
      public string? profile { get; set; }
      public string? remotePublicAddress { get; set; }
      public string? state { get; set; }
      public string? title { get; set; }
      public string? version { get; set; }
      public bool local { get; set; }
      public bool relayed { get; set; }
      public bool secure { get; set; }
      public int userID { get; set; }
   }

   public class Session
   {
      public string? id { get; set; }
      public int bandwidth { get; set; }
      public string? location { get; set; }
   }

   [Newtonsoft.Json.JsonObject(Id = "")]
   public class CurrentlyPlaying
   {
      public MediaContainer? MediaContainer { get; set; }
   }
}