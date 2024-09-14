using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Services.Interfaces
{
    public interface IFileManager
    {
        [Obsolete] public void Save<T>(string name, T data, bool reWrite);
        [Obsolete] public void Delete(string name);
        [Obsolete] public string GetFileText(string fileName);
        [Obsolete] public byte[] GetFileBytes(string fileName);
        [Obsolete] public List<string> EnumerateFolderFiles(string folderName);
        [Obsolete] public void Configure(string workDirectory, string defaultFolderName);
        [Obsolete] public void DeleteFile(string path, string name);
        public byte[] GetFileData<T>(string path, string name, out string? data);
        public void SaveFile<T>(string path, string name, T data, bool overWrite);
        public void AppendToList<T>(string fileName, T item);
        public void SaveInFolder<T>(string folderName, string fileName, T content, bool overWrite);
        public List<string> EnumerateFolderFiles(string path, string folderName);
    }
}
