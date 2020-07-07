using System;
using System.Runtime.Serialization;

namespace binaryHeap
{
    [Serializable]
    internal class HeapEmptyException : Exception
    {
        public HeapEmptyException()
        {
        }

        public HeapEmptyException(string message) : base(message)
        {
        }

        public HeapEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HeapEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}