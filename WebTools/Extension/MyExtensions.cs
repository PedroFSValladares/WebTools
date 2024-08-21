using Microsoft.AspNetCore.Identity;
using WebTools.Models;
using WebTools.Services.Interfaces;
using WebTools.Services.Persistence;
using WebTools.Services.Web;

namespace WebTools.Extension
{
    public static class MyExtensions {
        public static void SetUpUserSettings(this ConfigurationManager configurationManager) {
            var userSettingsSection = configurationManager.GetSection("userSettings").Get<UserSettings>();
            string appPath = Path.GetDirectoryName(Environment.ProcessPath);

            Environment.SetEnvironmentVariable("appPath",appPath);
            foreach (var item in userSettingsSection.ToDictionary())
            {
                Environment.SetEnvironmentVariable(item.Key, item.Value);
            }

        }
        public static void SetUpServices(this IServiceCollection services) {
            services.AddScoped<IDownloader>(x => new Downloader());
            services.AddScoped<IFileManager>(x => new FileManager());
            services.AddScoped<PasswordHasher<User>>();
        }
    }
}
