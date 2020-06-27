using System.IO;

namespace SRP.Demo
{
    public class FileStoreOnly
    {
        public void WriteAllText(string path,string message)
        {
            File.WriteAllText(path, message);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public FileInfo GetPath(int id,DirectoryInfo WorkingDierctory)
        {
            return new FileInfo(Path.Combine(WorkingDierctory.FullName, id + ".txt"));
        }
    }
}
