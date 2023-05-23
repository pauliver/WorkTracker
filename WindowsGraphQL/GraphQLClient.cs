using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using System.IdentityModel;

namespace WindowsGraphQL
{

   public class TokenProvider : IAccessTokenProvider
   {
      private readonly IPublicClientApplication publicClientApplication;
      public TokenProvider(string clientId, string tenantId)
      {
         publicClientApplication = PublicClientApplicationBuilder
               .Create(clientId)
               .WithTenantId(tenantId)
               .Build();
         AllowedHostsValidator = new AllowedHostsValidator();
      }
      public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
            CancellationToken cancellationToken = default)
      {
         var scopes = new[] { "User.Read" };
         var result = await publicClientApplication.AcquireTokenByIntegratedWindowsAuth(scopes).ExecuteAsync(); ;
         // get the token and return it in your own way
         return result.AccessToken;
      }

      public AllowedHostsValidator AllowedHostsValidator { get; }
   }


   public class GraphQLClient
   {
      public GraphQLClient()
      {
         
      }
   }

}
