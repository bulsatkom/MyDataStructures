namespace MyList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class myList<T> : System.Collections.Generic.IEnumerable<T>
    {
        const int InitialCapacity = 4;

        private T[] buffer;
        private int capacity;
        private int count;

        public myList()
        {
            this.buffer = new T[InitialCapacity];
            this.capacity = 4;
            this.count = 0;
        }

        private void Resize(int newsize)
        {
            var newbuffer = new T[newsize];

            for (int i = 0; i < this.buffer.Length; i++)
            {
                newbuffer[i] = this.buffer[i];
            }

            this.buffer = newbuffer;
            this.capacity = newsize;
        }

        public T this[int index]
        {
            get
            {
                return buffer[index];
            }
            set
            {
                buffer[index] = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T value)
        {
            if (this.Count == this.Capacity)
            {
                Resize(this.Capacity * 2);
            }

            this.buffer[this.count] = value;
            ++this.count;
        }

        public void AddAt(T value, int index)
        {
            if (this.count < index)
            {
                throw new ArgumentException("Invalid Index");
            }

            if (this.count == this.capacity)
            {
                Resize(this.Capacity * 2);
            }

            for (int i = this.count; i > index; i--)
            {
                this.buffer[i] = this.buffer[i - 1];
            }

            this.buffer[index] = value;
            ++this.count;
        }

        public void AddRange(int startindex, int count, T[] values)
        {
            if (this.capacity <= this.count + count)
            {
                Resize(this.Capacity * 2);
            }

            int endIndex = startindex + count;
            for (int i = this.count + count - 1; i >= endIndex; i--)
            {
                this.buffer[i] = this.buffer[i - count];
            }

            int counter = 0;
            for (int i = startindex; i < endIndex; i++)
            {
                this.buffer[i] = values[counter];
                ++counter;
                ++this.count;
            }
        }

        public void Remove()
        {
            --this.count;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.count - 1)
            {
                throw new ArgumentException("Index Is Not Valid!");
            }

            for (int i = index; i < this.count - 1; i++)
            {
                this.buffer[i] = this.buffer[i + 1];
            }

            --this.count;
        }

        public void RemoveRange(int startindex, int count)
        {
            if (startindex < 0 || startindex > this.count - 1 || startindex + count > this.count)
            {
                throw new ArgumentException("Index Is Not Valid!");
            }

            int endindex = startindex + count;
            for (int i = startindex; i < this.count - count; i++)
            {
                this.buffer[i] = this.buffer[i + count];
            }

            for (int i = 0; i < count; i++)
            {
                --this.count;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.buffer)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
