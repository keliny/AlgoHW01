using System;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class SingleListStack : ISingleListStack
    {
        private readonly SingleLinkedList _list;
        private int Counter { get; set; }
        public SingleListStack(SingleLinkedList list)
        {
            _list = list;
            Counter = 1;
        }
        public void Push(Item item)
        {
            _list.Prepend(item);
            Counter++;
        }

        public Item Pop()
        {
            if (Counter == 0)
            {
                throw new StackOverflowException("Underflow of stack.");
            }
            var deleted = _list.DeleteAt(0);
            Counter--;
            return deleted;
        }
    }
}