using System;

namespace KataBinary
{
    class Program
    {
        // ^ represents XOR - false + true = true, true + true = false, false + false = false
        // Console.WriteLine(false ^ true);
        // | - OR
        // & - AND

        static void Main(string[] args)
        {
            
            BitArray();
            SingleLinkedList();
            SingleListStack();
            BitArrayStack();
            SingleListQueueM();
            BooleanArrayQueueM();

            Console.ReadKey(true);
            Console.ReadLine();
        }

        private static void BooleanArrayQueueM()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------  BooleanArrayQueue  ---------------------------");
            var array = new BooleanArrayQueue(3);

            Console.WriteLine("Queue");
            array.Queue(false);
            array.Queue(true);
            array.Queue(true);
            Console.WriteLine();
            Console.WriteLine("Dequeue");
            Console.WriteLine(array.DeQueue());
            Console.WriteLine(array.DeQueue());
            Console.WriteLine(array.DeQueue());
        }

        private static void SingleListQueueM()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------  SingleListQueue  ---------------------------");
            var header = new Item() { Value = "object 1" };
            var singleList = new SingleLinkedList(header);
            var queue = new SingleListQueue(singleList);

            var item1 = new Item { Value = "object 2" };

            Console.WriteLine("Queue");
            queue.Queue(item1);
            Console.WriteLine();
            Console.WriteLine("Dequeue");
            Console.WriteLine(queue.DeQueue().Value);
            Console.WriteLine(queue.DeQueue().Value);
        }

        private static void BitArrayStack()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------  BitArrayStack  ---------------------------");
            var array = new BooleanArrayStack(2);

            Console.WriteLine("Push");
            array.Push(false);
            array.Push(false);
            Console.WriteLine();
            Console.WriteLine("Pop");
            Console.WriteLine(array.Pop());
            
        }

        private static void SingleListStack()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------  SingleListStack  ---------------------------");
            var header = new Item { Value = "object 1" };
            var singleList = new SingleLinkedList(header);
            var stack = new SingleListStack(singleList);

            var item1 = new Item{Value = "object 2"};


            Console.WriteLine("Push");
            stack.Push(item1);
            Console.WriteLine();
            Console.WriteLine("Pop");
            var deleted = stack.Pop();
            Console.WriteLine($"Deleted {deleted.Value}");
            deleted = stack.Pop();
            Console.WriteLine($"Deleted {deleted.Value}");
//            deleted = stack.Pop();
//            Console.WriteLine($"Deleted {deleted.Value}");

        }

        private static void SingleLinkedList()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------  SingleLinkedList  ---------------------------");
            var header = new Item() {Value = "object 1"};
            var singleList = new SingleLinkedList(header);

            var prependItem = new Item { Value = "prepended item." };
            var appendItem = new Item { Value = "appended item" };
            var insertBefore = new Item {Value = "New insert before item."};
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Insert");
            singleList.Insert(1, new Item {Value = "Object 2"});
            singleList.Cycle();
            Console.WriteLine();
            singleList.Insert(1, new Item { Value = "Object 3" });
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Get index");
            singleList.GetItem(0);
            singleList.FindItem(header);
            Console.WriteLine();
            Console.WriteLine("set ");
            singleList.SetItem(1, new Item{Value = "Updated item"});
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Append");
            singleList.Append(appendItem);
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Prepend");
            singleList.Prepend(prependItem);
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Delete at 2");
            singleList.DeleteAt(2);
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Insert before prependItem");
            singleList.InsertBefore(prependItem, insertBefore);
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Insert after prependItem");
            singleList.InsertAfter(prependItem, new Item { Value = "New insert after item." });
            singleList.Cycle();
            Console.WriteLine();
            singleList.InsertAfter(appendItem, new Item { Value = "Second insert after item." });
            singleList.Cycle();
            Console.WriteLine();
            Console.WriteLine("Remove by Item");
            singleList.Remove(insertBefore);
            singleList.Cycle();

        }

        public static void BitArray()
        {
            var length = 7;
            // Create a bool array with desired length
            var boolArray = new BoolArray(length);
            Console.WriteLine("---------------------------  BitArray ---------------------------");

            boolArray.Setter(0, true);
            Console.WriteLine("Set value 1 at index 0");
            boolArray.DisplayArray();
            boolArray.Setter(1, true);
            Console.WriteLine("Set value 1 at index 1");
            boolArray.DisplayArray();
            boolArray.Setter(2, true);
            Console.WriteLine("Set value 1 at index 2");
            boolArray.DisplayArray();
            boolArray.Setter(1, false);
            Console.WriteLine("Set value 0 at index 1");
            boolArray.DisplayArray();
            boolArray.Insert(0, false);
            Console.WriteLine("Set value 0 at index 0");
            boolArray.DisplayArray();
            boolArray.Remove(0);
            Console.WriteLine("removed value at index 0");
            boolArray.DisplayArray();
            boolArray.Append(true);
            Console.WriteLine("Appended 1");
            boolArray.DisplayArray();
            boolArray.Prepend(true);
            Console.WriteLine("Prepended 1");
            boolArray.DisplayArray();
            boolArray.Prepend(false);
            Console.WriteLine("Prepended 0");
            boolArray.DisplayArray();
        }
    }
}