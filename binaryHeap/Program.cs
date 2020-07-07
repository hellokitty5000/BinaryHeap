using System;
using System.Collections.Generic;

namespace binaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //parent is index-1 /2
            //left child is index*2 + 1
            //right child is index*2 + 2

            //heapify up: add to end of array
            //compare the value to its parent and swap if it is greater than its parent while index > 0

            Random rand = new Random(43);
            Heap<int> heap = new Heap<int>();
            const int HEAP_SIZE = 50;
            for (int i = 0; i < HEAP_SIZE; i++)
            {
                heap.Insert(rand.Next(0, 100));
            }

            List<int> vals = heap.HeapSort();

            Console.WriteLine(string.Join(',', vals));

            //heap.display();

            //while (heap.Count > 0)
            //{
            //    Console.WriteLine(heap.pop());
            //}
            //heap.display();
        }
    }
}
