using System;
using System.Collections.Concurrent;
using System.IO;

namespace SRP.Demo
{
    public class FileStoreStep1
    {
        private readonly ConcurrentDictionary<int, string> cache;
        public FileStoreStep1(DirectoryInfo wd)
        {
            //example of fail fast
            // according to postels law we should be tolerant about input, now we should be explicit about the problem
            // and how the caller can solve the problem
            if (wd==null)
                throw new ArgumentNullException("Working directory cannot be null");
            if (!wd.Exists)
                throw new ArgumentNullException("Working directory does not exists, its not your fault but there was no way to design static typed pre-condition, please provide a valid path");
            this.WorkingDierctory = wd;
            this.cache = new ConcurrentDictionary<int, string>();

        }
        public DirectoryInfo WorkingDierctory { get; private set; }

        public void Save(int id, string message)
        {
            Console.WriteLine($"Saving to file with id {id}");
            var fileInfo = this.GetPath(id);//Query we can call query from command
            File.WriteAllText(fileInfo.FullName, message);
            this.cache.AddOrUpdate(id, message, (i, s) => message);
            Console.WriteLine($"Saved to file with id {id}");
        }

        public MayBe<string> Read(int id)
        {
            Console.WriteLine($"Reading from file with id {id}");
            var file = this.GetPath(id);
            //we can go for fail fast
            if (!file.Exists)
            {
                Console.WriteLine($"Did not found message from file with id {id}");
                return new MayBe<string>(); 
            }
            var message=this.cache.GetOrAdd(id,_ => File.ReadAllText(file.FullName));
            Console.WriteLine($"Returning message from file with id {id}");
            return new MayBe<string>(message);
        }

        public FileInfo GetPath(int id)
        {
            return new FileInfo(Path.Combine(this.WorkingDierctory.FullName, id + ".txt"));
        }

    }
}
