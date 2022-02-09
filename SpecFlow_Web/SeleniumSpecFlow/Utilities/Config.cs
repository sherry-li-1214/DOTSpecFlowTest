using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SeleniumSpecFlow.Utilities
{
    class Config
    {
        public static bool RemoteBrowser => bool.Parse(GetValue("RemoteBrowser"));

        public static BrowserType Browser
            => (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"));

        public static string Platform => GetValue("Platform");
        public static string WebUrl => GetValue("WebUrl");
        public static string ApiUrl => GetValue("ApiUrl");
        public static string Username => GetValue("Username");
        public static string Password => GetValue("Password");

        public static bool UseSeleniumGrid => bool.Parse(GetValue("UseSeleniumGrid"));
        public static string GridHubUri => GetValue("GridHubUrl");

      private static string GetValue(string value)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(parentDirName)
                .AddJsonFile("appsettings.json");
            return builder.Build()[value];
        }
    }
}
