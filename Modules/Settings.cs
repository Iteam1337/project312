namespace project312.modules
{
    public static class Settings
    {
        public static string PostgresHost { get; set; }
        public static string DatabaseName { get; set; }
        public static string PostgresPassword { get; set; }
        public static string ConnectionString { get; set; }

        static Settings()
        {
            DatabaseName = "subscriptions";
        }
    }
}