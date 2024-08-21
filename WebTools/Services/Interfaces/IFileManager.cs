using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Services.Interfaces
{
    public interface IFileManager
    {
        public void Save<T>(string name, T data, bool reWrite);
        public void AppendToList<T>(string fileName, T item);
        public string GetFileText(string fileName);
        public byte[] GetFileBytes(string fileName);
        public void SaveInFolder<T>(string folderName, string fileName, T content, bool overWrite);
        public List<string> EnumerateFolderFiles(string folderName);
        public void Configure(string workDirectory, string defaultFolderName);
    }
}
