namespace MyDoubleLinkedList
{
    using System;

    public class DoubleLinkedList<T>
    {
        public DoubleLinkedList()
        {
            this.First = null;
            this.Last = null;
            this.Count = 0;
        }

        public DoubleLinkedNode<T> First { get; set; }
        public DoubleLinkedNode<T> Last { get; set; }
        public int Count { get; private set; }

        public void Add(T Value)
        {
            var node = new DoubleLinkedNode<T>(Value);
            if(this.First == null && this.Last == null)
            {
                this.First = node;
                this.Last = node;
            }
            else
            {
                this.Last.Next = node;
                node.Prev = this.Last;
                this.Last = node;
            }

            ++this.Count;
        }

        public void AddAfter(DoubleLinkedNode<T> node, T Value)
        {
            var newNode = new DoubleLinkedNode<T>(Value);
            if (node.Next == null)
            {
                node.Next = newNode;
                newNode.Prev = node;
                this.Last = newNode;
            }
            else
            {
                node.Next.Prev = newNode;
                newNode.Next = node.Next;
                node.Next = newNode;
                newNode.Prev = node;
            }

            ++this.Count;
        }

        public void AddBefore(DoubleLinkedNode<T> node, T value)
        {
            var newnode = new DoubleLinkedNode<T>(value);
            if (node.Prev == null)
            {
                node.Prev = newnode;
                newnode.Next = node;
                this.First = newnode;
            }
            else
            {
                node.Prev.Next = newnode;
                newnode.Prev = node.Prev;
                node.Prev = newnode;
                newnode.Next = node;
            }

            ++this.Count;
        }

        public void Remove(DoubleLinkedNode<T> value)
        {
            --this.Count;
            if(value.Prev != null)
            {
                value.Prev.Next = value.Next;
            }
            else
            {
                this.First = value.Next;
            }

            if(value.Next != null)
            {
                value.Next.Prev = value.Prev;
            }
            else
            {
                this.Last = value.Prev;
            }
        }

        public void RemoveLast()
        {
            this.Remove(this.Last);
        }

        public void RemoveFirst()
        {
            this.Remove(this.First);
        }

    }
}
