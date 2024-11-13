using MyStudio.Framework.Interface;

namespace MyStudio.Framework
{
    public class GameStateMachine : IGameStateMachine
    {
        private IGameState _currentState;

        public void ChangeState(IGameState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = newState;
            _currentState.Enter();
        }
    }
}
