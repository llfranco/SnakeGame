using UnityEngine;

namespace SnakeGame
{
    public interface ISnake
    {
        void ChangeColor(Color color);

        void ChangeMovementDirection(Vector2Int direction);

        void IncreaseBodySize();
    }
}
