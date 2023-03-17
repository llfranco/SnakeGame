using UnityEngine;
using UnityEngine.InputSystem;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(PlayerSettings), fileName = nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField]
        private Color _color;

        [SerializeField]
        private InputAction _moveNorthAction;

        [SerializeField]
        private InputAction _moveSouthAction;

        [SerializeField]
        private InputAction _moveWestAction;

        [SerializeField]
        private InputAction _moveEastAction;

        public Color Color => _color;

        public InputAction MoveNorthAction => _moveNorthAction;

        public InputAction MoveSouthAction => _moveSouthAction;

        public InputAction MoveWestAction => _moveWestAction;

        public InputAction MoveEastAction => _moveEastAction;
    }
}
