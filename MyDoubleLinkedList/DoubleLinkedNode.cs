namespace MyDoubleLinkedList
{
    using System;

    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode(T value)
        {
            this.Value = value;
            this.Next = null;
            this.Prev = null;
        }

        public T Value { get; set; }
        public DoubleLinkedNode<T> Next { get; set; }
        public DoubleLinkedNode<T> Prev { get; set; }
    }
}
