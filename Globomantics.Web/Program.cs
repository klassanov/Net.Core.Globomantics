using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Globomantics.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                //Deviate from defaults and configure other configuration sources
                //.ConfigureAppConfiguration((ctx, cfg) =>
                //{
                //    cfg.AddInMemoryCollection();
                //    cfg.AddCommandLine();
                //    cfg.AddEnvironmentVariables();
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
