using MyStudio.Framework.Interface;
using MyStudio.Framework.GameSystem;
using UnityEngine;

namespace MyStudio.Framework.GameState
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

            InitSystem();
            InitGameStateMachine();
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void InitSystem()
        {
            _systemGroup = new();
            _systemGroup.RegisterSystem(new GameEventSystem());
        }

        private void InitGameStateMachine()
        {
            _gameStateMachine = new GameStateMachine();
            _gameStateMachine.ChangeState(new GameState_Init());
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
