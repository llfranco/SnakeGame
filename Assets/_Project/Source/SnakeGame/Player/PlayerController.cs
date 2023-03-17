using UnityEngine;
using UnityEngine.InputSystem;

namespace SnakeGame
{
    public sealed class PlayerController
    {
        private readonly PlayerSettings _settings;
        private readonly ISnake _snake;

        public PlayerController(PlayerSettings settings, ISnake snake)
        {
            _settings = settings;
            _snake = snake;
            _snake.ChangeColor(settings.Color);

            BindInputActionListeners();
        }

        public void EnableInputs()
        {
            _settings.MoveNorthAction.Enable();
            _settings.MoveSouthAction.Enable();
            _settings.MoveWestAction.Enable();
            _settings.MoveEastAction.Enable();
        }

        public void DisableInputs()
        {
            _settings.MoveNorthAction.Disable();
            _settings.MoveSouthAction.Disable();
            _settings.MoveWestAction.Disable();
            _settings.MoveEastAction.Disable();
        }

        private void BindInputActionListeners()
        {
            _settings.MoveNorthAction.performed += HandleMoveNorthInputActionPerformed;
            _settings.MoveSouthAction.performed += HandleMoveSouthInputActionPerformed;
            _settings.MoveWestAction.performed += HandleMoveWestInputActionPerformed;
            _settings.MoveEastAction.performed += HandleMoveEastInputActionPerformed;
        }

        private void HandleMoveNorthInputActionPerformed(InputAction.CallbackContext context)
        {
            _snake.ChangeMovementDirection(Vector2Int.up);
        }

        private void HandleMoveSouthInputActionPerformed(InputAction.CallbackContext context)
        {
            _snake.ChangeMovementDirection(Vector2Int.down);
        }

        private void HandleMoveWestInputActionPerformed(InputAction.CallbackContext context)
        {
            _snake.ChangeMovementDirection(Vector2Int.left);
        }

        private void HandleMoveEastInputActionPerformed(InputAction.CallbackContext context)
        {
            _snake.ChangeMovementDirection(Vector2Int.right);
        }
    }
}
