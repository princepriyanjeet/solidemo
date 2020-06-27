using System;
using System.IO;

namespace CodeThatSucks
{
    public class FileStore
    {
        public string WorkingDirectory { get; set; }
        public string Save(int id,string message)
        {
            var path = Path.Combine(this.WorkingDirectory, id + ".txt");
            File.WriteAllText(path, message);
            return path;
        }

        public event EventHandler<MessageEventArgs> MessageRead;
        public void Read(int id)
        {
            var path = Path.Combine(this.WorkingDirectory, id + ".txt");
            var message=File.ReadAllText(path);
            if (this.MessageRead != null)
            {
                this.MessageRead(this, new MessageEventArgs { Message = message });
            }
        }
    }
}
