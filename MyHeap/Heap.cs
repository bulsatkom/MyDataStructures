namespace MyHeap
{
    using System;
    using System.Collections.Generic;

    public class Heap<T>
    {
        private List<T> buffer;
        private Func<T, T, bool> cmp;

        public Heap(Func<T,T,bool> comp)
        {
            this.buffer = new List<T>();
            this.buffer.Add(default(T));
            this.cmp = comp;
        }
        
        public T GetTop
        {
            get
            {
                return this.buffer[1];
            }
        }

        public int Count
        {
            get
            {
                return this.buffer.Count - 1;
            }
        }

        public void Add(T value)
        {
            this.buffer.Add(value);

            int index = this.Count;

            while(index > 1 && this.cmp(buffer[index], this.buffer[index / 2]))
            { 
                var item = this.buffer[index];
                this.buffer[index] = this.buffer[index / 2];
                this.buffer[index / 2] = item;
                index = index / 2;
            }
        }

        public void Remove()
        {
            this.buffer[1] = this.buffer[this.Count];
            this.buffer.RemoveAt(this.Count);

            var index = 1;
            int smallerindex = this.cmp(this.buffer[index * 2], this.buffer[index * 2 + 1])
                   ? index * 2
                   : index * 2 + 1;

            while ((index * 2 + 1) <= this.Count && !cmp(this.buffer[index], this.buffer[smallerindex]))
            {
                smallerindex = this.cmp(this.buffer[index * 2], this.buffer[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (!cmp(this.buffer[index], this.buffer[smallerindex]))
                {
                    var item = this.buffer[index];
                    this.buffer[index] = this.buffer[smallerindex];
                    this.buffer[smallerindex] = item;
                }

                index = smallerindex;
            }

            if(index * 2 <= this.Count && !cmp(this.buffer[index], this.buffer[index * 2]))
            {
                var item = this.buffer[index];
                this.buffer[index] = this.buffer[index * 2];
                this.buffer[index * 2] = item;
            }
        }
    }
}
