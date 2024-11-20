using System.Collections.Generic;

namespace MyStudio.Framework.GameSystem
{
    public class GameEventSystem : InGameSystem
    {
        private Dictionary<string, object> _events;

        public override void Init()
        {
            _events = new();
        }

        public override void Destroy() {}

        public GameEvent<T> GetEvent<T>(string eventName)
        {
            if (!_events.ContainsKey(eventName))
            {
                _events[eventName] = null;
            }

            return (GameEvent<T>)_events[eventName];
        }
    }
}
