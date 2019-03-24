namespace KataBinary.Interfaces
{
    public interface IBooleanArrayQueue
    {
        void Queue(bool val);
        bool DeQueue();
    }
}