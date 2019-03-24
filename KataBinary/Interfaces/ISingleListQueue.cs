namespace KataBinary.Interfaces
{
    public interface ISingleListQueue
    {
        void Queue(Item item);
        Item DeQueue();
    }
}