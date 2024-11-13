namespace MyStudio.Framework.Interface
{
    public interface IGameStateMachine
    {
        void ChangeState(IGameState newState);
    }
}
