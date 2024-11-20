namespace MyStudio.Framework.GameSystem
{
    public class GameEvent<T>
    {
        private System.Action<T> _onEvent;

        public void Invoke(T data)
        {
            _onEvent?.Invoke(data);
        }

        public void Subscribe(System.Action<T> listener)
        {
            _onEvent += listener;
        }

        public void Unsubscribe(System.Action<T> listener)
        {
            _onEvent -= listener;
        }
    }
}
