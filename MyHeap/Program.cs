namespace MyHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var Heap = new Heap<int>((x, y) => x < y);
            var list = new List<int> { 131, 5, 4, 100, 50, 200, 35, 42, 33, 22, 21, 15, 10, 11, 3 };
            Console.WriteLine(string.Join(" ", list));
            for (int i = 0; i < list.Count; i++)
            {
                Heap.Add(list[i]);
                Console.Write(Heap.GetTop + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Count " + Heap.Count);
            Heap.Remove();
            Console.WriteLine(Heap.GetTop);
            Console.WriteLine("Count " + Heap.Count);
            Heap.Remove();
            Console.WriteLine(Heap.GetTop);
            Console.WriteLine("Count " + Heap.Count);
            Heap.Remove();
            Console.WriteLine(Heap.GetTop);
            Console.WriteLine("Count " + Heap.Count);
        }
    }
}
