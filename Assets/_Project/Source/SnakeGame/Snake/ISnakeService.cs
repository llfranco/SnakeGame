using SnakeGame.Common;

namespace SnakeGame
{
    public interface ISnakeService : IService
    {
        ISnake SpawnSnake();
    }
}
