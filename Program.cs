using System.IO;
using Microsoft.AspNetCore.Hosting;
using project312.modules;
namespace project312
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            Settings.PostgresHost = "127.0.0.1";
            Settings.PostgresPassword = "o768lLr$a1v8"; 
            foreach (var arg in args)
            {
                if (arg == "mode=container")
                {
                    Settings.PostgresHost = "the-postgres";
                    Settings.PostgresPassword = "password"; 
                }

            }
            
            System.Threading.Thread.Sleep(15000);
            Settings.ConnectionString = "Host=" + Settings.PostgresHost + ";Username=subs_user;Password=531h4Kb%6$y9;Database=" + Settings.DatabaseName; // this should be done somewhere else later on
            DatabaseInitializer.initDatabase();
            host.Run();
        }
    }
}
