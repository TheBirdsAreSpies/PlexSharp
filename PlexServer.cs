using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using PlexSharp.Exceptions;
using PlexSharp.ApiObjects;
using System.Net;
using System.Reflection;
using System.Text;

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

               if (null == user.authToken)
               {
                  throw new LoginException("Auth token not found.");
               }
               _authToken = user.authToken;
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

      public MediaContainer CurrentlyPlaying()
      {
         using (HttpClient client = new HttpClient())
         {
            AddDefaultHeaders(client);
            var result = client.GetAsync(BaseUrl + "/status/sessions").Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;

            JObject o = JObject.Parse(responseContent);
            return o.SelectToken("MediaContainer")!.ToObject<MediaContainer>() ?? throw new InvalidOperationException();
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
   }
}