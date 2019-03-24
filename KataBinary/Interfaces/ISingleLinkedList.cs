namespace KataBinary.Interfaces
{
    public interface ISingleLinkedList
    {
        // Get item with this index
        void GetItem(int index);

        // check whether this object exists in the list
        void FindItem(Item item);

        // set value of this index to this object??
        void SetItem(int index, Item item);

        // append
        void Append(Item item);

        // prepend
        void Prepend(Item item);

        // Delete at index
        Item DeleteAt(int index);
        
        // Insert
        void Insert(int index, Item item);

        // Insert before
        void InsertBefore(Item itemBefore, Item item);

        // Insert after
        void InsertAfter(Item itemAfter, Item item);

        // remove
        void Remove(Item item);

        // Cycle
        void Cycle();
    }
}