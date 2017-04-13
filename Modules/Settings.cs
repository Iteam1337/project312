using System;

namespace project312.modules
{
    public static class Settings
    {
        public static string PostgresHost { get; private set; }
        public static string DatabaseName { get; private set; }
        public static string PostgresPassword { get; private set; }
        public static string ConnectionString { get; private set; }

        static Settings()
        {
            DatabaseName = "subscriptions";
            PostgresPassword = "password";
            var postgresHostEnv = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            PostgresHost = postgresHostEnv != null ? postgresHostEnv : "127.0.0.1";
            Console.WriteLine(String.Format("PostgresHost is {0}",  Settings.PostgresHost)); 
            ConnectionString = "Host=" + PostgresHost + ";Username=subs_user;Password=531h4Kb%6$y9;Database=" + DatabaseName + ";";
        }
    }
}