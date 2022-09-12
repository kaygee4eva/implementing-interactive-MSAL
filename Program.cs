using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace KENAUTH
{
    class Program
    {
        private const string _clientId = "70b05ff9-5dba-4edd-bdab-6817f61bfff2";
        private const string _tenantId = "171bbb46-cbe0-46d9-9282-b192adb86e55";

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build();
            string[] scopes = { "user.read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}