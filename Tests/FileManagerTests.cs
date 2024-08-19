using Akka.Actor.Setup;
using System.Text;
using WebTools.Services.Persistence;
using WebTools.Services.Persistence.Interfaces;

namespace Tests {
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



        [TearDown]
        public void CleanUp() {
            Directory.Delete(TestDirectory, true);
        }
    }
}