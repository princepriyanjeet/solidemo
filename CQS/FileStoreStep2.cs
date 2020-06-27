using System;
using System.IO;

namespace CQS
{
    /// <summary>
    /// input
    /// </summary>
    public class FileStoreStep2
    {
        /// <summary>
        /// Here we are running a precondition(protecting the invariants)
        /// in C# we cant add some static type systems to check precondition, but depend on guard clause at run time
        /// </summary>
        /// <param name="wd"></param>
        public FileStoreStep2(string wd)
        {
            //example of fail fast
            // according to postels law we should be tolerant about input, now we should be explicit about the problem
            // and how the caller can solve the problem
            if (string.IsNullOrEmpty(wd))
                throw new ArgumentNullException("Working directory cannot be null");
            if(!Directory.Exists(wd))
                throw new ArgumentNullException("Working directory does not exists, its not your fault but there was no way to design static typed pre-condition, please provide a valid path");
            this.WorkingDierctory = wd;

        }
        private string _wd;
        public string WorkingDierctory { get;  set; }

        public void Save(int id, string message)
        {
            var path = this.GetPath(id);//Query we can call query from command
            File.WriteAllText(path, message);
        }

        public string Read(int id)
        {
            var path = this.GetPath(id);
            var message = File.ReadAllText(path);
            return message;
        }

        public string GetPath(int id)
        {
            return Path.Combine(this.WorkingDierctory, id + ".txt");
        }
    }

    public class SomeTestFleClient
    {
        public void Execute()
        {
            FileStoreStep2 step = new FileStoreStep2(@"z:\logs");
        }
    }
}
