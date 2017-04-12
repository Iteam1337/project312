using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            Settings.PostgresPassword = "password";
            foreach (var arg in args)
            {
                if (arg == "mode=container")
                {
                    Settings.PostgresHost = "the-postgres";
                    System.Threading.Thread.Sleep(2000);
                }
            } 
            Settings.ConnectionString = "Host=" + Settings.PostgresHost + ";Username=subs_user;Password=531h4Kb%6$y9;Database=" + Settings.DatabaseName; // this should be done somewhere else later on
            DatabaseInitializer.initDatabase();
            
            host.Run();
        }
    }
}
