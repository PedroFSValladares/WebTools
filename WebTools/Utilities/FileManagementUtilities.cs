namespace WebTools.Utilities {
    public static class FileManagementUtilities {
        public static void CreateDiretoryIfNotExists(string directory) {
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }

        public static string GetNameForRepeteadFile(string filePath) {
            int counter = 0;

            while (File.Exists(filePath)) {
                counter++;
                   
                if(counter == 1) {
                    filePath = filePath.Insert(filePath.LastIndexOf("."), $" ({Convert.ToString(counter)})");
                } else {
                    filePath = filePath.Replace($" ({Convert.ToString(counter - 1)})", $" ({Convert.ToString(counter)})");
                }
            }
            return filePath;
        }

        public static string RemoveIllegalCharacters(string fileName) {
            List<char> illegalCharacters =
            [
                .. Path.GetInvalidFileNameChars().ToList(),
                .. Path.GetInvalidPathChars().ToList(),
            ];

            foreach(char illegalChar in illegalCharacters) {
                fileName = fileName.Replace(illegalChar.ToString(), "");
            }

            return fileName;
        }
    }
}
