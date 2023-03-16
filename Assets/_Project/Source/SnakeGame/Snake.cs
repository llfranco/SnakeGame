using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public interface ISnake
    {
        void IncreaseBodySize();
    }

    public interface IBoardObject
    {
    }

    public sealed class Snake : MonoBehaviour, ISnake
    {
        [SerializeField]
        private SnakeSettings _settings;

        private Vector2Int _direction;
        private SnakeBodyPart _head;
        private List<SnakeBodyPart> _bodyParts;
        private List<RecordedBoardObjectMovement> _headRecordedMovements;

        public void StartMoving()
        {
            InvokeRepeating(nameof(Move), _settings.StartMovingDelay, _settings.MovementRate);
        }

        public void StopMoving()
        {
            CancelInvoke(nameof(Move));
        }

        public void ChangeMovementDirection(Vector2Int direction)
        {
            if (direction == Vector2Int.left && _direction == Vector2Int.right || (direction == Vector2Int.right && _direction == Vector2Int.left))
            {
                return;
            }

            if (direction == Vector2Int.up && _direction == Vector2Int.down || direction == Vector2Int.down && _direction == Vector2Int.up)
            {
                return;
            }

            _direction = direction;
        }

        public void IncreaseBodySize()
        {
            CreateBodyPart();
            UpdateBodyPartPositions();
        }

        private void Awake()
        {
            _direction = Vector2Int.down;
            _bodyParts = new List<SnakeBodyPart>();
            _headRecordedMovements = new List<RecordedBoardObjectMovement>();

            CreateHead();
            StartMoving();
        }

        private void CreateHead()
        {
            _head = Instantiate(_settings.HeadPrefab);
        }

        private void CreateBodyPart()
        {
            _bodyParts.Add(Instantiate(_settings.BodyPartPrefab));
        }

        private void Move()
        {
            _headRecordedMovements.Insert(0, new RecordedBoardObjectMovement
            {
                GridPosition = _head.GridPosition,
                Rotation = _head.Rotation,
            });

            if (_headRecordedMovements.Count > _bodyParts.Count + 1)
            {
                _headRecordedMovements.RemoveAt(_headRecordedMovements.Count - 1);
            }

            UpdateBodyPartPositions();

            float movementAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

            if (movementAngle < 0)
            {
                movementAngle += 360;
            }

            _head.Rotation = Quaternion.Euler(new Vector3(0, 0, movementAngle - 90));
            _head.GridPosition += _direction * _settings.MovementSpeed;
        }

        private void UpdateBodyPartPositions()
        {
            for (int i = 0; i < _bodyParts.Count; i++)
            {
                _bodyParts[i].GridPosition = _headRecordedMovements[i].GridPosition;
                _bodyParts[i].Rotation = _headRecordedMovements[i].Rotation;
            }
        }
    }
}
