using FFMpegCore;

namespace Services.Persistence {
    public class FileManager {
        private string DefaultFolderName { get; set; }
        private string WokingDirectoy {  get; set; }
        private List<char> IllegalCharacters { get; set; }

        public FileManager() {
            IllegalCharacters = new List<char> { '/', '\\' , ':', '*', '\"', '<', '>', '|'};
        }

        public void Save(string name, byte[] data) {
            string newFileName = GetFileName(name);
            string directory = Path.Combine(WokingDirectoy, DefaultFolderName);
            string filePath = Path.Combine(directory, $"{newFileName}");
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

        public void Save(string name, string data) {
            string newFileName = GetFileName(name);
            string directory = Path.Combine(WokingDirectoy, DefaultFolderName);
            string filePath = Path.Combine(directory, $"{newFileName}");
            int counter = 0;

            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            while (File.Exists(filePath)) {
                counter++;
                filePath = filePath.Insert(filePath.LastIndexOf("."), $" ({Convert.ToString(counter)})");
            }

            var file = File.CreateText(Path.Combine(filePath));
            file.Write(data);
            file.Close();
            file.Dispose();
        }
        
        public string GetFileContent(string fileName) {
            string filePath = Path.Combine(WokingDirectoy, DefaultFolderName, fileName);
            return File.ReadAllText(filePath);
        }

        public byte[] GetFileData(string fileName) {
            string filePath = Path.Combine(WokingDirectoy, DefaultFolderName, fileName);
            return File.ReadAllBytes(filePath);
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

        public void Configure(string workDirectory, string defaultFolderName) {
            DefaultFolderName = defaultFolderName;
            WokingDirectoy = workDirectory;
        }

    }
}
