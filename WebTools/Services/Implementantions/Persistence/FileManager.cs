using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebTools.Services.Interfaces;
using WebTools.Utilities;


namespace WebTools.Services.Implementantions.Persistence
{
    public class FileManager : IFileManager
    {
        private string WorkingDirectory { get; set; }

        public void Save<T>(string name, T content, bool overWrite)
        {
            string filePath;
            FileStream file;
            byte[] contentToSave;
            FileManagementUtilities.CreateDiretoryIfNotExists(WorkingDirectory);

            string fileName = FileManagementUtilities.RemoveIllegalCharacters(name);
            filePath = overWrite ?
                Path.Combine(WorkingDirectory, $"{fileName}") : FileManagementUtilities.GetNameForRepeteadFile(
                    Path.Combine(WorkingDirectory, $"{fileName}"));

            if (content is string)
            {
                contentToSave = Encoding.UTF8.GetBytes(content as string);
            }
            else
            {
                contentToSave = content as byte[];
            }

            file = File.Create(filePath);
            file.Write(contentToSave);
            file.Close();
            file.Dispose();
        }

        public void Save(string name, string data, bool overWrite)
        {
            StreamWriter file;
            string filePath;

            FileManagementUtilities.CreateDiretoryIfNotExists(WorkingDirectory);

            string fileName = FileManagementUtilities.RemoveIllegalCharacters(name);
            filePath = overWrite ?
                Path.Combine(WorkingDirectory, $"{fileName}") : FileManagementUtilities.GetNameForRepeteadFile(
                    Path.Combine(WorkingDirectory, $"{fileName}"));

            file = File.CreateText(filePath);
            file.Write(data);
            file.Close();
            file.Dispose();
        }

        public string GetFileText(string fileName)
        {
            string filePath = Path.Combine(WorkingDirectory, fileName);
            return File.ReadAllText(filePath);
        }

        public byte[] GetFileBytes(string fileName)
        {
            string filePath = Path.Combine(WorkingDirectory, fileName);
            return File.ReadAllBytes(filePath);
        }

        public FileStream GetFileStream(string path)
        {
            FileStream file = File.OpenRead(path);
            return file;
        }

        public void Configure(string workDirectory, string defaultFolderName)
        {
            WorkingDirectory = Path.Combine(workDirectory, defaultFolderName);
        }

        public void AppendToList<T>(string fileName, T item)
        {

            throw new NotImplementedException();
        }

        public List<string> EnumerateFolderFiles(string folderName)
        {
            string workingDirectoryWithFolderName = Path.Combine(WorkingDirectory, folderName);
            IEnumerable<string> files = new List<string>();

            try
            {
                files = Directory.EnumerateFiles(workingDirectoryWithFolderName);
            }
            catch (DirectoryNotFoundException e) { }

            return files.Select(x => Path.GetFileName(x)).ToList();
        }

        public void SaveInFolder<T>(string folderName, string fileName, T content, bool overWrite)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name) {
            File.Delete(Path.Combine(WorkingDirectory, name));
        }
    }
}
