using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SRP.Demo
{
    public class MessageStore
    {
        private readonly StoreCache cache;
        private readonly StoreLogger logger;
        private readonly FileStoreOnly fileStore;
        public MessageStore(DirectoryInfo wd)
        {
            //example of fail fast
            // according to postels law we should be tolerant about input, now we should be explicit about the problem
            // and how the caller can solve the problem
            if (wd == null)
                throw new ArgumentNullException("Working directory cannot be null");
            if (!wd.Exists)
                throw new ArgumentNullException("Working directory does not exists, its not your fault but there was no way to design static typed pre-condition, please provide a valid path");
            this.WorkingDierctory = wd;
            this.cache = new StoreCache();
            this.logger = new StoreLogger();
            this.fileStore = new FileStoreOnly();

        }
        public DirectoryInfo WorkingDierctory { get; private set; }

        public void Save(int id, string message)
        {
            this.logger.Saving(id);
            var fileInfo = this.GetPath(id);//Query we can call query from command
            this.fileStore.WriteAllText(fileInfo.FullName, message);
            this.cache.AddOrUpdate(id, message);
            this.logger.Saved(id);
        }

        public MayBe<string> Read(int id)
        {
            this.logger.Reading(id);
            var file = this.GetPath(id);
            //we can go for fail fast
            if (!file.Exists)
            {
                this.logger.DifNotFind(id);
                return new MayBe<string>();
            }
            var message = this.cache.GetOrAdd(id, _ => this.fileStore.ReadAllText(file.FullName));
            this.logger.Returning(id);
            return new MayBe<string>(message);
        }

        public FileInfo GetPath(int id)
        {
            return new FileInfo(Path.Combine(this.WorkingDierctory.FullName, id + ".txt"));
        }
    }
}
