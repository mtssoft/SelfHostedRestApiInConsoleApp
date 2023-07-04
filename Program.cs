

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfHostedRestApiInConsoleApp;
using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

var configInstance = new Config();
config.Bind("Config", configInstance);

CreateHostBuider(args, configInstance).Build().Run();


static IHostBuilder CreateHostBuider(string[] args, Config configInstance) => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseUrls($"{configInstance.BaseUrl}");
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton(configInstance);
        });