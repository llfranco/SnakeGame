using UnityEngine;

namespace SnakeGame
{
    public sealed class SnakeBodyPart : MonoBehaviour
    {
        private Transform _transform;
        private Vector2Int _gridPosition;

        public Vector2Int GridPosition
        {
            get => _gridPosition;
            set
            {
                _gridPosition = value;
                _transform.position = new Vector3(value.x, value.y);
            }
        }

        public Quaternion Rotation { get => _transform.rotation; set => _transform.rotation = value; }

        private void Awake()
        {
            _transform = transform;
            _gridPosition = Vector2Int.zero;
        }
    }
}
