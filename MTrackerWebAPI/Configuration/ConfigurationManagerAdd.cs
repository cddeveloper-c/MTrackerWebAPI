namespace MTrackerWebAPI.Configuration
{
    static class ConfigurationManagerAdd
    {
        public static IConfiguration AppSetting
        {
            get;
        }
        static ConfigurationManagerAdd()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
