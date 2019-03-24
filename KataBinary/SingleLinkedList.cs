using System;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class SingleLinkedList : ISingleLinkedList
    {
        // Head - contains first item of the single list
        private ListItem Head { get; set; }

        public SingleLinkedList(Item header)
        {
            Head = new ListItem
            {
                Item = header,
                NextItem = null
            };
        }

        public void Insert(int index, Item item)
        {
            ListItem curItem = null;
            ListItem nextItem = Head;
            ListItem previousItem = null;

            if (index == 0)
            {
                Prepend(item);
            }
            else
            {
                for (var i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        var newItem = new ListItem() {Item = item, NextItem = nextItem};
                        previousItem.NextItem = newItem;
                    }
                    else
                    {
                        curItem = nextItem ?? throw new Exception("Index out of range.");
                        nextItem = curItem.NextItem;
                        previousItem = curItem;
                    }
                }
            }
        }

        public void GetItem(int index)
        {
            var ind = 0;
            if (Head == null || index < 0)
            {
                throw new Exception("index out of list.");
            }

            ListItem curItem;
            ListItem nextItem = Head;

            while (true)
            {
                if (ind == index)
                {
                    Console.WriteLine($"Found item, it's value is {nextItem.Item.Value}");
                    break;
                }

                curItem = nextItem;

                nextItem = curItem.NextItem ?? throw new Exception("Item not found.");
                ind++;
            }
        }

        public void FindItem(Item item)
        {
            ListItem curItem;
            ListItem nextItem = Head;

            while (true)
            {
                curItem = nextItem;
                if (curItem.Item == item)
                {
                    Console.WriteLine($"Item was found in the list. It's value is: {curItem.Item.Value}");
                    break;
                }

                if (curItem.NextItem == null)
                {
                    Console.WriteLine("Requested item was not found in the list.");
                    break;
                }

                nextItem = curItem.NextItem;
            }
        }

        public void SetItem(int index, Item item)
        {
            var ind = 0;
            if (Head == null || index < 0)
            {
                throw new Exception("index out of list.");
            }

            ListItem curItem;
            ListItem nextItem = Head;

            while (true)
            {
                if (ind == index)
                {
                    nextItem.Item = item;
                    break;
                }

                curItem = nextItem;

                nextItem = curItem.NextItem ?? throw new Exception("Item not found.");
                ind++;
            }
        }

        public void Append(Item item)
        {
            ListItem curItem = null;
            ListItem nextItem = Head;

            while (true)
            {
                curItem = nextItem;

                if (curItem.NextItem == null)
                {
                    curItem.NextItem = new ListItem {Item = item, NextItem = null};
                    break;
                }

                nextItem = curItem.NextItem;
            }
        }

        public void Prepend(Item item)
        {
            var headLink = Head.NextItem;
            var headItem = Head.Item;

            Head.NextItem = new ListItem {Item = headItem, NextItem = headLink};
            Head.Item = item;
        }

        public Item DeleteAt(int index)
        {
            ListItem curItem = null;
            ListItem nextItem = Head;
            ListItem previousItem = null;

            Item deletedItem = new Item();

            if (index == 0)
            {
                deletedItem = Head.Item;

                if (Head.NextItem == null)
                {
                    Head = new ListItem();
                }
                else
                {
                    Head = nextItem.NextItem;
                }
            }
            else
            {
                for (var i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        
                        var check = nextItem ?? throw new Exception("Index out of range.");
                        deletedItem = curItem.Item;
                        curItem.NextItem = nextItem.NextItem;
                    }
                    else
                    {
                        curItem = nextItem ?? throw new Exception("Index out of range.");
                        nextItem = curItem.NextItem;
                        previousItem = curItem;
                    }
                }
            }

            return deletedItem;
        }


        public void InsertBefore(Item itemBefore, Item item)
        {
            ListItem curItem;
            ListItem nextItem = Head;
            ListItem previousItem = null;

            while (true)
            {
                curItem = nextItem;

                if (curItem.Item == itemBefore)
                {
                    var newItemList = new ListItem {Item = item, NextItem = curItem};

                    if (previousItem == null)
                    {
                        // it's head
                        Prepend(item);
                        break;
                    }
                    else
                    {
                        previousItem.NextItem = newItemList;
                        break;
                    }
                }

                if (curItem.NextItem == null)
                {
                    Console.WriteLine("Requested item was not found in the list.");
                    break;
                }

                nextItem = curItem.NextItem;

                previousItem = curItem;
            }
        }

        public void InsertAfter(Item itemAfter, Item item)
        {
            ListItem curItem;
            ListItem nextItem = Head;

            while (true)
            {
                curItem = nextItem;

                if (curItem.Item == itemAfter)
                {
                    var newItemList = new ListItem {Item = item, NextItem = curItem.NextItem};
                    curItem.NextItem = newItemList;
                    break;
                }

                if (curItem.NextItem == null)
                {
                    Console.WriteLine("Requested item was not found in the list.");
                    break;
                }

                nextItem = curItem.NextItem;
            }
        }

        public void Remove(Item item)
        {
            ListItem curItem;
            ListItem nextItem = Head;
            ListItem previousItem = null;

            while (true)
            {
                curItem = nextItem;
                if (curItem.Item == item)
                {
                    if (previousItem == null)
                    {
                        DeleteAt(0);
                        break;
                    }

                    previousItem.NextItem = curItem.NextItem;
                    break;
                }

                if (curItem.NextItem == null)
                {
                    Console.WriteLine("Requested item was not found in the list.");
                    break;
                }

                nextItem = curItem.NextItem;
                previousItem = curItem;
            }
        }

        public void Cycle()
        {
            Console.WriteLine("Cycling through items");
            var i = 0;

            if (Head == null)
            {
            }
            else
            {
                ListItem curItem = null;
                ListItem nextItem = Head;

                while (true)
                {
                    curItem = nextItem;
                    var nextItemName = "";
                    nextItemName = curItem.NextItem == null ? "null" : curItem.NextItem.Item.Value;
                    Console.WriteLine(
                        $"Displaying Item: {i} with value: {curItem.Item.Value}. And next Item being {nextItemName}");

                    if (curItem.NextItem == null)
                        break;

                    nextItem = curItem.NextItem;
                    i++;
                }
            }
        }
    }
}