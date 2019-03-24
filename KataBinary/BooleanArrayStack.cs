using System;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class BooleanArrayStack : IBooleanArrayStack
    {
        private readonly BoolArray _array;
        private int Counter { get; set; }
        private readonly int _length;

        public BooleanArrayStack(int length)
        {
            _length = length;
            _array = new BoolArray(length);
            Counter = 0;
        }
        public void Push(bool val)
        {
            if (Counter == _length)
            {
                throw new StackOverflowException("Array is full.");
            }
            _array.Prepend(val);
            Counter++;
        }

        public bool Pop()
        {
            if (Counter == 0)
            {
                throw new StackOverflowException("Nothing to remove here. Underflow of stack.");
            }
            var deleted = _array.Remove(0);
            Counter--;
            return deleted;
        }
    }
}