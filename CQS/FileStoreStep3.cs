using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CQS
{
    /// <summary>
    /// Output
    /// </summary>
    public class FileStoreStep3
    {
        /// <summary>
        /// Here we are running a precondition(protecting the invariants)
        /// in C# we cant add some static type systems to check precondition, but depend on guard clause at run time
        /// </summary>
        /// <param name="wd"></param>
        public FileStoreStep3(string wd)
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

        /// <summary>
        /// we are guareteing we will return somethng
        /// it may happed the assoicted id doe not have a message
        /// it may happen the associated id may have message
        /// we can throw expection if the associated id is not there, but again we are not guareenting here as valid id will have message and some id will throw error
        /// we can go for empty string but again this is problematic some id may have emtpty message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Read(int id)
        {
            var path = this.GetPath(id);
            //we can go for fail fast
            if (!File.Exists(path))
            {
                throw new ArgumentException("you suck!","id");
            }
            var message = File.ReadAllText(path);
            return message;
        }

        /// <summary>
        /// This breaks this flent Api, not thread safe but we can handle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool TryRead(int id,out string message)
        {
            message = null;
            var path = this.GetPath(id);
            //we can go for fail fast
            if (!File.Exists(path))
            {
                return false;
            }
               
            message = File.ReadAllText(path);
            return true;
        }

        public bool Exists(int id)
        {
            var path = this.GetPath(id);
            return File.Exists(path);
        }

        /// <summary>
        /// Tester and doer
        /// This workks but not thread safe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string CanRead(int id)
        {
            var message = "";
            if(this.Exists(id))
                    message = File.ReadAllText(this.GetPath(id));
            return message;
        }

        public string GetPath(int id)
        {
            //always guarentees it will return a path whether it is valid or invalid, it just constructs the string, remember we have working directory set to not not null guard clause
            return Path.Combine(this.WorkingDierctory, id + ".txt");
        }
    }
}
