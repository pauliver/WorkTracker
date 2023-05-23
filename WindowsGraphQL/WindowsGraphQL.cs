using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace WindowsGraphQL
{
    public class WindowsGraphQL : PluginArchitecture.SharedPluginCode, PluginArchitecture.PluginInterface
   {

      private static GraphServiceClient _graphServiceClient;
      private static HttpClient _httpClient;

      private static GraphServiceClient GetAuthenticatedGraphClient(IConfigurationRoot config)
      {
         var authenticationProvider = CreateAuthorizationProvider(config);
         _graphServiceClient = new GraphServiceClient(authenticationProvider);
         return _graphServiceClient;
      }

      private static HttpClient GetAuthenticatedHTTPClient(IConfigurationRoot config)
      {
         var authenticationProvider = CreateAuthorizationProvider(config);
         _httpClient = new HttpClient(new AuthHandler(authenticationProvider, new HttpClientHandler()));
         return _httpClient;
      }

      private static IAuthenticationProvider CreateAuthorizationProvider(IConfigurationRoot config)
      {
         var clientId = config["applicationId"];
         var clientSecret = config["applicationSecret"];
         var redirectUri = config["redirectUri"];
         var authority = $"https://login.microsoftonline.com/{config["tenantId"]}/v2.0";

         List<string> scopes = new List<string>();
         scopes.Add("https://graph.microsoft.com/.default");

         var cca = ConfidentialClientApplicationBuilder.Create(clientId)
                                                 .WithAuthority(authority)
                                                 .WithRedirectUri(redirectUri)
                                                 .WithClientSecret(clientSecret)
                                                 .Build();
         return new MsalAuthenticationProvider(cca, scopes.ToArray());
      }


      bool IsInitialized = false;
      bool IsRunning = false;
      bool IsRegistered = false;
      public WindowsGraphQL()
      {
         bool IsInitialized = false;
         bool IsRunning = false;
         bool IsRegistered = false;
      }

      public override void Register()
      {
         base.Register();
      }

      public override void DeRegister()
      {
         base.DeRegister();
      }
      // in seconds
      public override int GetDesiredTickFrequency()
      {
         return 60;
      }

      public override void Initialize()
      {
         base.Initialize();
      }

      public override void LoadSettings(FileInfo fi)
      {
         base.LoadSettings(fi);
      }

      public override void Run()
      {
         base.Run();
      }

      public override void Pause(bool UnPause = false)
      {
         base.Pause(UnPause);
      }

      public override void Tick(int Seconds)
      {
         base.Tick(Seconds);

      }

      public override void Stop()
      {
         base.Stop();

      }
   }
}
