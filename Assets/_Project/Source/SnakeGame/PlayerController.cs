using UnityEngine;

namespace SnakeGame
{
    public sealed class PlayerController : MonoBehaviour
    {
        private Snake _snake;

        public void SetSnake(Snake snake)
        {
            _snake = snake;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _snake.ChangeMovementDirection(Vector2Int.left);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _snake.ChangeMovementDirection(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _snake.ChangeMovementDirection(Vector2Int.up);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _snake.ChangeMovementDirection(Vector2Int.down);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                _snake.IncreaseBodySize();
            }
        }
    }
}
