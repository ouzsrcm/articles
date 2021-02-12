using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Articles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .UseSerilog((hostingContext, loggerConfiguration) => 
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration).Enrich.FromLogContext())
               .Build()
               .Run();
        }
    }
}
