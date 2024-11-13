using MyStudio.Framework.Interface;

namespace MyStudio.Framework
{
    public abstract class GameState : IGameState
    {
        public abstract void Enter();
        public abstract void Exit();
    }
}
