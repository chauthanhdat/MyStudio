using MyStudio.Framework.Interface;
using MyStudio.Framework.GameSystem;
using UnityEngine;

namespace MyStudio.Framework
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                return _instance;
            }

            private set {}
        }

        private IGameStateMachine _gameStateMachine;
        private SystemGroup _systemGroup;

        private void Awake()
        {
            _instance = this;
            DontDestroyOnLoad(this);

            _gameStateMachine = new GameStateMachine();
            _systemGroup = new();
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        public void ChangeState(IGameState newState)
        {
            _gameStateMachine.ChangeState(newState);
        }

        public void RegisterSystem<T>(T system) where T : InGameSystem
        {
            _systemGroup.RegisterSystem(system);
        }

        public void UnregisterSystem<T>() where T : InGameSystem
        {
            _systemGroup.UnregisterSystem<T>();
        }

        public T GetSystem<T>() where T : InGameSystem
        {
            return _systemGroup.GetSystem<T>();
        }
    }
}
