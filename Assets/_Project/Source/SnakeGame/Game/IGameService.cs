using SnakeGame.Common;

namespace SnakeGame
{
    public delegate void GameHandler();

    public interface IGameService : IService
    {
        event GameHandler OnLateGameEnd;

        void BeginGame();
    }
}
