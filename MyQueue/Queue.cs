namespace MyQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyQueue<T> : IEnumerable<T>
    {
        const int InitialCapacity = 4;

        private T[] buffer;
        private int firstIndex;
        private int lastIndex;

        public MyQueue()
        {
            this.buffer = new T[InitialCapacity];
            this.firstIndex = 0;
            this.lastIndex = 0;
            this.Count = 0;
            this.Capacity = InitialCapacity;
        }

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        private void Resize(int newsize)
        {
            var newbuffer = new T[newsize];
            int index = this.lastIndex;
            for (int i = 0; i < this.Count; i++)
            {
                newbuffer[i] = this.buffer[index];
                index = this.NextIndex(index); 
            }

            this.buffer = newbuffer;
            this.lastIndex = 0;
            this.firstIndex = this.Count;
            this.Capacity = newsize;
        }

        private int NextIndex(int index)
        {
            if(index == this.buffer.Length -1)
            {
                return 0;
            }
            else
            {
                return ++index;
            }
        }

        public void Add(T value)
        {
            if(this.Count == this.Capacity)
            {
                Resize(this.Count * 2);
            }

            this.buffer[this.firstIndex] = value;
            this.firstIndex = NextIndex(this.firstIndex);
            ++this.Count;
        }    

        public void Remove()
        {
            this.buffer[this.lastIndex] = default(T);
            this.lastIndex = this.NextIndex(this.lastIndex);
            --this.Count;
        }

        public T GetFirst()
        {
            return this.buffer[this.lastIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.buffer[this.lastIndex];
                this.lastIndex = this.NextIndex(this.lastIndex);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
