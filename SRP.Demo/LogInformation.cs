using System;
using System.Collections.Generic;
using System.Text;

namespace SRP.Demo
{
    public class StoreLogger
    {
        public void Saving(int id)
        {
            Console.WriteLine($"Saving message with id {id}");
        }

        public void Saved(int id)
        {
            Console.WriteLine($"Saving message with id {id}");
        }

        public void Reading(int id)
        {
            Console.WriteLine($"Reading message with id {id}");
        }

        public void DifNotFind(int id)
        {
            Console.WriteLine($"No message found with {id} id");
        }

        public void Returning(int id)
        {
            Console.WriteLine($"Returning message from id {id}");
        }
    }
}
