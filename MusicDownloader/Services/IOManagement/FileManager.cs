namespace MusicDownloader.Services.IOManagement {
    public class FileManager {
        private string DefaultFolderName { get; set; }
        private List<char> IllegalCharacters { get; set; }

        public FileManager(string defautlFolderName) {
            DefaultFolderName = defautlFolderName;
            IllegalCharacters = new List<char> { '/', '\\' , ':', '*', '\"', '<', '>', '|'};
        }

        public void Save(string name, (string extension, string directory) ext, byte[] data) {
            string newFileName = GetFileName(name);
            string filePath = Path.Combine(ext.directory, DefaultFolderName);

            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }

            var file = File.Create(Path.Combine(filePath, $"{newFileName}.{ext.extension}"));
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
