using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace binaryHeap
{
    // min heap
    public class Heap<T> where T: IComparable<T>
    {
   
        List<T> heapList;

        public int Count => heapList.Count;
        public Heap()
        {
            heapList = new List<T>();
        }
        void heapifyUp()//only happens on the last value
        {
            int currentIndex = heapList.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                T parent = heapList[parentIndex];
                T child = heapList[currentIndex];

                if (child.CompareTo(parent) < 0)
                {
                    heapList[parentIndex] = child;
                    heapList[currentIndex] = parent;
                }

                currentIndex = parentIndex;
            }

        }
        void heapifyDown()
        {
            int index = 0;

            while (index < Count)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;
                int childIndex = leftChildIndex;
                if (leftChildIndex >= Count)
                {
                    break;
                }
                if (rightChildIndex < Count && heapList[leftChildIndex].CompareTo(heapList[rightChildIndex]) > 0)
                {
                    childIndex = rightChildIndex;
                }

                if(heapList[index].CompareTo(heapList[childIndex])> 0)
                {
                    T temp = heapList[childIndex];
                    heapList[childIndex] = heapList[index];
                    heapList[index] = temp;
                }
                // only swap if whatever at index is larger than childindex
                

                index = childIndex;

            }
             
        }
        public void Insert(T value)
        {
            heapList.Add(value);
            heapifyUp();
        }
        public List<T> HeapSort()
        {
            var heap = new Heap<T>();

            foreach (var item in heapList)
            {
                heap.Insert(item);
            }

            List<T> sortedHeap = new List<T>();
            while(heap.Count > 0)
            {
                sortedHeap.Add(heap.Pop());
            }

            return sortedHeap;
            
   
        }
        public T Pop()
        {
            if (heapList.Count == 0)
            {
                throw new HeapEmptyException("Cannot pop, heap is empty.");
            }
            T root = heapList.First();
            T temp = heapList[Count - 1];
            heapList[0] = temp;
            heapList.RemoveAt(Count - 1);

            heapifyDown();
            return root;
        }
        public void Display()
        {
            Console.WriteLine(string.Join(',', heapList));
        }

        public void DrawHeap()
        {
            int x = Console.WindowWidth / 2;
            drawHeap(0, x, 0, 10);
        }

        void drawHeap(int index, int x, int y, int dx)
        {
            if (index >= Count)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(heapList[index]);
            drawHeap(index * 2 + 1, x - dx, y + 1, dx - 2);
            drawHeap(index * 2 + 2, x + dx, y + 1, dx - 2);
        }
    }
}
