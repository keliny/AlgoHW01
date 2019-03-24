using System;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class SingleListQueue : ISingleListQueue
    {
        private readonly SingleLinkedList _list;
        private int Counter { get; set; }
        public SingleListQueue(SingleLinkedList list)
        {
            _list = list;
            Counter = 1;
        }
        public void Queue(Item item)
        {
            _list.Append(item);
            Counter++;
        }

        public Item DeQueue()
        {
            if (Counter == 0)
            {
                throw new Exception("Queue is empty.");
            }
            var deleted = _list.DeleteAt(0);
            Counter--;
            return deleted;
        }
    }
}