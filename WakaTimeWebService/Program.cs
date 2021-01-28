using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;

namespace WakaTimeWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
   
                    
                    var builtConfig = config.Build();
                    try
                    {
                        var credential = new ClientSecretCredential(
                            builtConfig["AzureKeyVault:TenantId"],
                            builtConfig["AzureKeyVault:AppClientId"],
                            builtConfig["AzureKeyVault:AppClientSecret"]
                        );

                        config.AddAzureKeyVault(
                            new Uri(builtConfig["AzureKeyVault:VaultUrl"]),
                            credential
                        );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    


                })
                    .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
