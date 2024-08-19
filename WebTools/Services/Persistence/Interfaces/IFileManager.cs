using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Services.Persistence.Interfaces
{
    public interface IFileManager
    {
        public void Save<T>(string name, T data, bool reWrite);
        public void AppendToList<T>(string fileName, T item);
        public string GetFileText(string fileName);
        public byte[] GetFileBytes(string fileName);
        public void Configure(string workDirectory, string defaultFolderName);
    }
}
