using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SRP.Demo
{
    public class MayBe<T> : IEnumerable<T>
    {
        IEnumerable<T> values;

        public MayBe()
        {
            values = new T[0] ;
        }
        public MayBe(T value)
        {
            values = new T[] { value };
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
