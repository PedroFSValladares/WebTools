namespace MusicDownloader.Services.IOManagement {
    public class FileManager {
        private string DefaultPath { get; set; }
        private List<char> IllegalCharacters { get; set; }

        public FileManager() {
            DefaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MediaDownload");
            IllegalCharacters = new List<char> { '/', '\\' , ':', '*', '\"', '<', '>', '|'};
        }

        public void Save(string name, string extension, byte[] data) {
            if (!Directory.Exists(DefaultPath)) {
                Directory.CreateDirectory(DefaultPath);
            }
            name = GetFileName(name);
            string filePath = DefaultPath + $"/{name}.{extension}";

            var file = File.Create(filePath);
            file.Write(data);
            file.Close();
            file.Dispose();
        }

        public FileStream GetFileStream(string path) {
            FileStream file = File.OpenRead(path);
            return file;
        }

        private string GetFileName(string name) {
            string newName = name;
            IllegalCharacters.ForEach(x => {
                newName = name.Replace(x.ToString(), "");
            });
            return newName;
        }


    }
}
