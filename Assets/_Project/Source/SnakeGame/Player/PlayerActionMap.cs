using UnityEngine;
using UnityEngine.InputSystem;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/Player Action Map", fileName = nameof(PlayerActionMap))]
    public class PlayerActionMap : ScriptableObject
    {
        [SerializeField]
        private InputAction _moveNorthAction;

        [SerializeField]
        private InputAction _moveSouthAction;

        [SerializeField]
        private InputAction _moveWestAction;

        [SerializeField]
        private InputAction _moveEastAction;

        public InputAction MoveNorthAction => _moveNorthAction;

        public InputAction MoveSouthAction => _moveSouthAction;

        public InputAction MoveWestAction => _moveWestAction;

        public InputAction MoveEastAction => _moveEastAction;
    }
}
