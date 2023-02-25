using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Wintellect.PowerCollections
{
    public class Stack<Type> : IEnumerable
    {
        private Type[] Array; // stack
        public int Capacity = 0; // all available count
        public int Count = 0; // current count in array

        public Stack(int count)
        {
            this.Array = new Type[count];
            this.Capacity = count;
        }

        public Stack(Type[] array)
        {
            this.Array = new Type[array.Length];
            this.Array = array;
            this.Capacity = array.Length;
            this.Count = array.Length;
        }

        public Type[] Push(Type item)
        {
            if (this.Count == this.Capacity)
            {
                throw new IndexOutOfRangeException("Nope, my array is full");
            }

            this.Array[this.Count++] = item;
            return this.Array;
        }

        public Type Top()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Nope, my array is empty");
            }

            return this.Array[this.Count - 1];
        }

        public Type Pop()
        {
            Type returnValue = this.Top();

            this.Array = this.Array.Where((value, index) => index != this.Count - 1).ToArray();
            this.Count--;

            return returnValue;
        }

        public IEnumerator GetEnumerator()
        {
            return this.Array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}