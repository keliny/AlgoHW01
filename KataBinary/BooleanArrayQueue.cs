using System;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class BooleanArrayQueue : IBooleanArrayQueue
    {
        private readonly BoolArray _array;
        private int Counter { get; set; }
        private readonly int _length;

        public BooleanArrayQueue(int length)
        {
            _length = length;
            _array = new BoolArray(length);
            Counter = 0;
        }

        public void Queue(bool val)
        {
            if (Counter == _length)
            {
                throw new StackOverflowException("Array is full.");
            }
            _array.Prepend(val);
            Counter++;
        }

        public bool DeQueue()
        {
            if (Counter == 0)
            {
                throw new StackOverflowException("Nothing to remove here. Underflow of stack.");
            }
            var deleted = _array.Remove(Counter - 1);
            Counter--;
            return deleted;
        }
    }
}