using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Services.Persistence.Interfaces
{
    public interface IFileManager
    {
        public void Save(string name, byte[] data);
        public void Save(string name, string data, bool reWrite);
        public string GetFileContent(string fileName);
        public byte[] GetFileData(string fileName);
        public void Configure(string workDirectory, string defaultFolderName);
    }
}
