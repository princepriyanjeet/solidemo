using CQS.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace CQS
{
    public class FileStoreStep4
    {
        /// <summary>
        /// Here we are running a precondition(protecting the invariants)
        /// in C# we cant add some static type systems to check precondition, but depend on guard clause at run time
        /// </summary>
        /// <param name="wd"></param>
        public FileStoreStep4(string wd)
        {
            //example of fail fast
            // according to postels law we should be tolerant about input, now we should be explicit about the problem
            // and how the caller can solve the problem
            if (string.IsNullOrEmpty(wd))
                throw new ArgumentNullException("Working directory cannot be null");
            if (!Directory.Exists(wd))
                throw new ArgumentNullException("Working directory does not exists, its not your fault but there was no way to design static typed pre-condition, please provide a valid path");
            this.WorkingDierctory = wd;

        }
        public string WorkingDierctory { get; private set; }

        public void Save(int id, string message)
        {
            var path = this.GetPath(id);//Query we can call query from command
            File.WriteAllText(path, message);
        }

        public MayBe<string> Read(int id)
        {
            var path = this.GetPath(id);
            //we can go for fail fast
            if (!File.Exists(path))
                return new MayBe<string>();
            var message = File.ReadAllText(path);
            return new MayBe<string>(message);
        }

        public string GetPath(int id)
        {
            //always guarentees it will return a path whether it is valid or invalid, it just constructs the string, remember we have working directory set to not not null guard clause
            return Path.Combine(this.WorkingDierctory, id + ".txt");
        }

    }

    public class FileStorMayBeClient
    {
        public void Display()
        {
            FileStoreStep4 fileStore = new FileStoreStep4(@"d:\logs");
            var getVal=fileStore.Read(1).DefaultIfEmpty("").Single();
        }
    }
}
