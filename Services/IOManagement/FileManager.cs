using FFMpegCore;

namespace Services.IOManagement {
    public class FileManager {
        private string DefaultFolderName { get; set; }
        private List<char> IllegalCharacters { get; set; }

        public FileManager(string defautlFolderName) {
            DefaultFolderName = defautlFolderName;
            IllegalCharacters = new List<char> { '/', '\\' , ':', '*', '\"', '<', '>', '|'};
        }

        public void Save(string name, (string extension, string directory) ext, byte[] data) {
            string newFileName = GetFileName(name);
            string directory = Path.Combine(ext.directory, DefaultFolderName);
            string filePath = Path.Combine(directory, $"{newFileName}{ext.extension}");
            int counter = 0;

            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            while (File.Exists(filePath)) {
                counter++;
                filePath = filePath.Insert(filePath.LastIndexOf("."), $" ({Convert.ToString(counter)})");
            }

            var file = File.Create(Path.Combine(filePath));
            file.Write(data);
            file.Close();
            file.Dispose();
        }

        public void SaveTemporaly(){
            throw new NotImplementedException();
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
