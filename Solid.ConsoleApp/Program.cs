using System;
using CodeThatSucks;
namespace Solid.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStore store = new FileStore();
            store.WorkingDirectory = @"D:/Logs";
            store.Save(1, "Heo from prince");
            store.MessageRead += Store_MessageRead;
            store.Read(1);
            Console.ReadKey();
        }

        private static void Store_MessageRead(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
