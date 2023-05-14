using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlexSharp.Exceptions;
using PlexSharp.ApiObjects;
using System.Net;
using System.Reflection;
using System.Text;
using PlexSharp.ApiObjects.LibrarySections;

namespace PlexSharp
{
   public class PlexServer
   {
      private string? _authToken;
      private string _clientIdentifier;

      public bool IsAuthenticated { get; private set; }
      public string BaseUrl { get; private set; }

      public PlexServer(string baseUrl)
      {
         BaseUrl = baseUrl.TrimEnd('/');
         _clientIdentifier = Environment.MachineName;
      }

      public void Authenticate()
      {
         // TODO implement
         GeneratePin();
         throw new NotImplementedException();
      }

      private void GeneratePin()
      {
         // TODO implement
         // ref https://forums.plex.tv/t/authenticating-with-plex/609370
         throw new NotImplementedException();

#pragma warning disable CS0162 // Unreachable code detected
         using (HttpClient client = new HttpClient())
         {
            client.BaseAddress = new Uri(Urls.PINS);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent("true"), "strong");
            formData.Add(new StringContent("PlexSharp"), "X-Plex-Product");
            formData.Add(new StringContent(Environment.MachineName), "X-Plex-Client-Identifier");

            var result = client.PostAsync(Urls.PINS, formData).Result;
            var response = result.Content.ReadAsStringAsync().Result;

            var responseObj = JsonConvert.DeserializeObject<PinLogin>(response);
            if (null == responseObj)
            {
               throw new Exception("No response while authenticating!");
            }

            var id = responseObj.Id; // store locally
            var code = responseObj.Code; // construct auth app url
         }
#pragma warning restore CS0162 // Unreachable code detected
      }

      public void Authenticate(string username, string password)
      {
         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
         {
            throw new LoginException("Username or password is missing.");
         }

         string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

         using (HttpClient client = new HttpClient())
         {
            AddDefaultHeaders(client);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedCredentials);

            HttpResponseMessage response = client.PostAsync(Urls.SIGN_IN_LEGACY, null).Result;
            if (response.IsSuccessStatusCode)
            {
               string responseContent = response.Content.ReadAsStringAsync().Result;

               JObject o = JObject.Parse(responseContent);
               if (null == o)
               {
                  throw new LoginException("Invalid response.");
               }

               User user = o.SelectToken("user")!.ToObject<User>() ?? throw new InvalidOperationException();

               if (null == user.AuthToken)
               {
                  throw new LoginException("Auth token not found.");
               }
               _authToken = user.AuthToken;
               IsAuthenticated = true;
            }
         }
      }

      public void Authenticate(string token)
      {
         _authToken = token;
         IsAuthenticated = true;

         using(HttpClient client = new HttpClient())
         {
            AddDefaultHeaders(client);

            HttpResponseMessage response = client.GetAsync(BaseUrl + "/").Result;
            if (!response.IsSuccessStatusCode)
            {
               IsAuthenticated = false;
               throw new NotAuthorizedException("Provided token is invalid.");
            }
         }
      }

      public ApiObjects.CurrentlyPlaying.MediaContainer CurrentlyPlaying()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/status/sessions");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.CurrentlyPlaying.MediaContainer>() ?? throw new InvalidOperationException();
      }

      public ApiObjects.History.MediaContainer History()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/status/sessions/history/all");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.History.MediaContainer>() ?? throw new InvalidOperationException();
      }

      public void Search(string query)
      {
         // TODO implement
      }

      public ApiObjects.Library.MediaContainer Library()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/library");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.Library.MediaContainer>() ?? throw new InvalidOperationException();
      }

      public ApiObjects.LibrarySections.MediaContainer LibrarySections()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/library/sections");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.LibrarySections.MediaContainer>() ?? throw new InvalidOperationException();
      }

      public DirectoryType Library(string library)
      {
         // TODO maybe create a specific type to return
         var sections = LibrarySections();
         var specificLibrary = sections?.Directory?.Find((d) => d.Title!.Equals(library, StringComparison.InvariantCultureIgnoreCase));

         if (null == specificLibrary)
         {
            throw new NotFoundException("Library not found.");
         }

         return specificLibrary;
      }

      public void SystemInformation()
      {
         // TODO implement
         // returns XML instead of JSON
         var responseContent = GetJsonByUrl(BaseUrl + "/system");
         throw new NotImplementedException();
      }

      public void OnDeck()
      {
         // TODO implement
         // pretty similar to CurrentlyPlaying
         // use inheritance maybe
         var responseContent = GetJsonByUrl(BaseUrl + "/library/onDeck");
         JObject o = JObject.Parse(responseContent);
         throw new NotImplementedException();
      }

      public ApiObjects.Servers.MediaContainer Servers()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/servers");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.Servers.MediaContainer>() ?? throw new InvalidOperationException();
      }

      public ApiObjects.Preferences.MediaContainer Preferences()
      {
         var responseContent = GetJsonByUrl(BaseUrl + "/:/prefs");
         JObject o = JObject.Parse(responseContent);
         return o.SelectToken("MediaContainer")!.ToObject<ApiObjects.Preferences.MediaContainer>() ?? throw new InvalidOperationException();
      }

      #region "Internals"
      private HttpClient ClientWithHeaders()
      {
         HttpClient client = new HttpClient();
         AddDefaultHeaders(client);
         return client;
      }

      private string GetJsonByUrl(string url)
      {
         using (var client = ClientWithHeaders())
         {
            var result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
         }
      }

      private void AddDefaultHeaders(HttpClient client)
      {
         client.DefaultRequestHeaders.Add("Accept", "application/json");
         client.DefaultRequestHeaders.Add("X-Plex-Client-Identifier", _clientIdentifier);
         client.DefaultRequestHeaders.Add("X-Plex-Product", "PlexSharp");
         client.DefaultRequestHeaders.Add("X-Plex-Version", Assembly.GetEntryAssembly()!.GetName().Version!.ToString());

         if (IsAuthenticated)
         {
            client.DefaultRequestHeaders.Add("X-Plex-Token", _authToken);
         }
      }
      #endregion
   }
}