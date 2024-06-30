using System.Collections;
using System.Reflection;

namespace WebTools.Models
{
    public class UserSettings{
        public string youtubeVideoDownloadUrl { get; set; }
        public string defaultMediaDownloadFolderName { get; set; }
        public string userListFolderName { get; set; }
        
        public Dictionary<string, string> ToDictionary() {
            var dictionary = new Dictionary<string, string>();
            var keyValueProperties = GetType().GetProperties().Select<PropertyInfo, (string key, string value)>(x => {
                return (x.Name, x.GetValue(this).ToString());
            });
            foreach (var item in keyValueProperties){
                dictionary.Add(item.key, item.value);
            }
            return dictionary;
        }
        
    }
}