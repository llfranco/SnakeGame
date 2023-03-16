using UnityEngine;

namespace SnakeGame
{
    public sealed class SnakeBodyPart : MonoBehaviour, ISnakeBodyPart, IBoardObject
    {
        private Transform _transform;
        private Vector2Int _position;

        public ISnake Snake { get; set; }

        public Vector2Int Position
        {
            get => _position;
            set
            {
                if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
                {
                    return;
                }

                boardService.UnoccupyPosition(this);

                _position = value;
                _transform.position = new Vector3(value.x, value.y);

                boardService.OccupyPosition(this);
            }
        }

        public Quaternion Rotation
        {
            get => _transform.rotation;
            set => _transform.rotation = value;
        }

        private void Awake()
        {
            _transform = transform;
            _position = Vector2Int.zero;
        }
    }
}
