using UnityEngine;
using UnityEngine.InputSystem;

namespace SnakeGame
{
    public sealed class PlayerController
    {
        private readonly PlayerActionMap _actionMap;
        private readonly ISnake _snake;

        public PlayerController(PlayerActionMap actionMap, ISnake snake)
        {
            _actionMap = actionMap;
            _snake = snake;

            BindInputActionListeners();
        }

        public void EnableInputs()
        {
            _actionMap.MoveNorthAction.Enable();
            _actionMap.MoveSouthAction.Enable();
            _actionMap.MoveWestAction.Enable();
            _actionMap.MoveEastAction.Enable();
        }

        public void DisableInputs()
        {
            _actionMap.MoveNorthAction.Disable();
            _actionMap.MoveSouthAction.Disable();
            _actionMap.MoveWestAction.Disable();
            _actionMap.MoveEastAction.Disable();
        }

        private void BindInputActionListeners()
        {
            _actionMap.MoveNorthAction.performed += HandleMoveNorthInputActionPerformed;
            _actionMap.MoveSouthAction.performed += HandleMoveSouthInputActionPerformed;
            _actionMap.MoveWestAction.performed += HandleMoveWestInputActionPerformed;
            _actionMap.MoveEastAction.performed += HandleMoveEastInputActionPerformed;
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
