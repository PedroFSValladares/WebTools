using Akka.Actor.Setup;
using System.Text;
using WebTools.Services.Implementantions.Persistence;
using WebTools.Services.Interfaces;

namespace Tests
{
    public class FileManagerTests {

        private IFileManager fileManager;
        private string TestDirectory;

        [SetUp]
        public void Setup() {
            fileManager = new FileManager();
            fileManager.Configure(Path.GetDirectoryName(Environment.ProcessPath), "tests");
            TestDirectory = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "tests");
        }

        [Test]
        public void SaveTextFile() {
            string fileName = Path.GetFileName(Path.GetTempFileName());
            string content = "this is a text file, but saved as byte file";
            fileManager.Save(fileName, content, false);
            var fileByteContent = File.ReadAllText(Path.Combine(TestDirectory, fileName));
            Assert.IsTrue(content == fileByteContent);
        }

        [Test]
        public void SaveIllegalFiles() {
            fileManager.Save("|llegal\\file???.txt", "test", false);
            Assert.IsTrue(File.Exists(Path.Combine(TestDirectory, "llegalfile.txt")));
        }

        [Test]
        public void SaveRepeatedFileTest() {
            List<string> dataTest = new List<string> { 
                Path.Combine(TestDirectory, "repeated file.txt"),
                Path.Combine(TestDirectory, "repeated file (1).txt"),
                Path.Combine(TestDirectory, "repeated file (2).txt")
            };
            for(int i = 0; i <= 3; i++) {
                fileManager.Save("repeated file.txt", "teste", false);
            }

            foreach(var path in dataTest) {
                if (!File.Exists(path)) {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void EnumerateFilesFolder() {
            string fileTestName = "test.txt";
            int qntdFiles = 5;
            int counter = 0;

            for (int i = 0; i < qntdFiles; i++) {
                fileManager.Save(fileTestName, "test", false);
            }

            var serviceResult = fileManager.EnumerateFolderFiles("");

            Assert.IsTrue(serviceResult.Count == qntdFiles, "O metodo retornou uma quantidade menor de aquivos do que a quantidade que foi criada");

            for (int i = 0; i < qntdFiles; i++) {
                if (i == 0) {
                    Assert.IsTrue(serviceResult.Contains("test.txt"), "Um dos arquivos criados foi retornado com o nome incorreto");
                }else{
                    Assert.IsTrue(serviceResult.Contains($"test ({i}).txt"), "Um dos arquivos criados foi retornado com o nome incorreto");
                }
            }
        }

        [Test]
        public void EnumerateEmptyFolder() {
            Assert.IsTrue(fileManager.EnumerateFolderFiles("").Count == 0);
        }

        [TearDown]
        public void CleanUp() {
            var testFiles = Directory.EnumerateFiles(TestDirectory);
            foreach (var file in testFiles) {
                File.Delete(file);
            }
        }
    }
}