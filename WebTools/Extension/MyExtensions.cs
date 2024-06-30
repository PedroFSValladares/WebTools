using Microsoft.AspNetCore.Identity;
using Services.Downloader;
using Services.Persistence;
using WebTools.Models;

namespace WebTools.Extension
{
    public static class MyExtensions {
        public static void SetUpUserSettings(this ConfigurationManager configurationManager) {
            var userSettingsSection = configurationManager.GetSection("userSettings").Get<UserSettings>();
            string appPath = Environment.ProcessPath.Replace(Path.GetFileName(Environment.ProcessPath), "");

            Environment.SetEnvironmentVariable("appPath",appPath);
            foreach (var item in userSettingsSection.ToDictionary())
            {
                Environment.SetEnvironmentVariable(item.Key, item.Value);
            }

        }
        public static void SetUpServices(this IServiceCollection services) {
            services.AddScoped<Downloader>();
            services.AddScoped<FileManager>();
            services.AddScoped<PasswordHasher<User>>();
        }
    }
}
