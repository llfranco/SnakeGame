using UnityEngine;

namespace SnakeGame
{
    public interface ISnake
    {
        void ChangeMovementDirection(Vector2Int direction);

        void IncreaseBodySize();
    }
}
