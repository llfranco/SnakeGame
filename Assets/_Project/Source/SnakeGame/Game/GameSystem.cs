using UnityEngine;

namespace SnakeGame.Game
{
    public sealed class GameSystem : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _controller;

        [SerializeField]
        private Board _board;

        [SerializeField]
        private Snake _snake;

        private void Start()
        {
            _controller.SetSnake(_snake);
            _board.CreateSlots();
            _snake.SetPosition(_board.GetUnoccupiedPosition());
            _snake.StartMoving();
        }
    }
}
