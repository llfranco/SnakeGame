using SnakeGame.Common;

namespace SnakeGame
{
    public delegate void GameHandler();

    public interface IGameService : IService
    {
        event GameHandler OnGameEnd;

        void BeginGame();
    }
}
