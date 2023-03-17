namespace SnakeGame
{
    public interface IGameStateListener
    {
        void NotifyGameSetup();

        void NotifyGameBegin();

        void NotifyGameEnd();
    }
}
