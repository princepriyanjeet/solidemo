using System.IO;

namespace CQS
{
    public class FileStoreStep1
    {
        public string WorkingDierctory { get; set; }

        public void Save(int id,string message)
        {
            var path = this.GetPath(id);//Query we can call query from command
            File.WriteAllText(path, message);
        }

        public string Read(int id)
        {
            var path = this.GetPath(id);
            var message= File.ReadAllText(path);
            return message;
        }

        public string GetPath(int id)
        {
            return Path.Combine(this.WorkingDierctory, id + ".txt");
        }
    }

    public class SomeClient
    {
        public void Save()
        {
            FileStoreStep1 step = new FileStoreStep1();
            step.Save(2, "rtttyy");
        }
    }
}
