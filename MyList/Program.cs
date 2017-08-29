using MyDoubleLinkedList;
using MyQueue;
using mystack;
using System;

namespace MyList
{
    public class Program
    {
        static void Main()
        {
            //var list = new myList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(20);
            //list.Add(30);
            //list.Add(4);
            //list.Add(5);
            //list.RemoveRange(3, 2);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //var doubleLinkedList = new DoubleLinkedList<int>();
            //doubleLinkedList.Add(10);
            //doubleLinkedList.AddAfter(doubleLinkedList.Last, 7);
            //doubleLinkedList.AddBefore(doubleLinkedList.Last, 6);
            //doubleLinkedList.Remove(doubleLinkedList.Last);
            //var first = doubleLinkedList.First;
            //while(first != null)
            //{
            //    Console.WriteLine(first.Value);

            //    first = first.Next;
            //}

            //var q = new MyQueue<int>();

            //q.Add(1);
            //q.Add(2);
            //q.Add(3);
            //q.Add(4);
            //q.Add(5);
            //q.Add(6);
            //q.Add(7);
            //q.Remove();
            //q.Add(1);
            //q.Add(12);
            //q.Add(13);
            //q.Remove();

            //Console.WriteLine(string.Join(", ",q));

            var stack = new MyStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);
            stack.Add(4);
            stack.Add(5);
            stack.Add(6);
            Console.WriteLine(stack.Get());
            stack.Remove();
            Console.WriteLine(stack.Get());
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
