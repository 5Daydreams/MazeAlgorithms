namespace _Code.Observer.Listener
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}