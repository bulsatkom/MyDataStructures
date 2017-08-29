namespace mystack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> :IEnumerable<T>
    {
        const int INITIALCAPACITY = 4;

        private T[] buffer;
 
        public MyStack()
        {
            this.buffer = new T[INITIALCAPACITY];
            this.Count = 0;
            this.Capacity = INITIALCAPACITY;
        }
        
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        private void Resize(int newsize)
        {
            var newbuffer = new T[newsize];

            for (int i = 0; i < this.buffer.Length; i++)
            {
                newbuffer[i] = this.buffer[i];
            }

            this.buffer = newbuffer;
            this.Capacity = newsize;
        }

        public void Add(T value)
        {
            if(this.Count == this.Capacity)
            {
                Resize(this.Count * 2);
            }

            this.buffer[this.Count] = value;
            ++this.Count;
        }

        public void Remove()
        {
            --this.Count;
        }

        public T Get()
        {
            return this.buffer[this.Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = this.Count - 1;
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.buffer[index];
                --index;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
