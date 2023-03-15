using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public struct TransformRecord
    {
        public Vector2Int GridPosition;
        public Quaternion Rotation;
    }

    

    public sealed class Snake : MonoBehaviour
    {
        [SerializeField]
        private SnakeSettings _settings;

        private Transform _transform;
        private Vector2Int _gridPosition;
        private Vector2Int _direction;
        private List<SnakeBodyPart> _bodyParts;
        private List<TransformRecord> _movementHistory;

        public void StartMoving()
        {
            InvokeRepeating(nameof(Move), _settings.StartMovingDelay, _settings.MovementRate);
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
            _bodyParts.Add(Instantiate(_settings.BodyPartPrefab));

            for (int i = 0; i < _bodyParts.Count; i++)
            {
                _bodyParts[i].transform.position = new Vector3(_movementHistory[i].GridPosition.x, _movementHistory[i].GridPosition.y);
                _bodyParts[i].transform.rotation = _movementHistory[i].Rotation;
            }
        }

        private void Awake()
        {
            _transform = transform;
            _gridPosition = Vector2Int.zero;
            _direction = Vector2Int.down;
            _bodyParts = new List<SnakeBodyPart>();
            _movementHistory = new List<TransformRecord>();

            StartMoving();
        }

        private void Move()
        {
            _movementHistory.Insert(0, new TransformRecord
            {
                GridPosition = _gridPosition,
                Rotation = _transform.rotation,
            });

            if (_movementHistory.Count > _bodyParts.Count + 1)
            {
                _movementHistory.RemoveAt(_movementHistory.Count - 1);
            }

            Debug.Log($"{nameof(_movementHistory)} Count: {_movementHistory.Count}");

            foreach (TransformRecord transformRecord in _movementHistory)
            {
                Debug.Log($"{nameof(transformRecord)}: {transformRecord.GridPosition}");
            }

            Debug.Log("---------------");

            for (int i = 0; i < _bodyParts.Count; i++)
            {
                _bodyParts[i].transform.position = new Vector3(_movementHistory[i].GridPosition.x, _movementHistory[i].GridPosition.y);
                _bodyParts[i].transform.rotation = _movementHistory[i].Rotation;

                Debug.Log($"{nameof(_bodyParts)}[{i}]: {_movementHistory[i].GridPosition}");
            }

            Debug.Log("---------------");

            _gridPosition += _direction * _settings.MovementSpeed;

            float movementAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

            if (movementAngle < 0)
            {
                movementAngle += 360;
            }

            _transform.position = new Vector3(_gridPosition.x, _gridPosition.y);
            _transform.eulerAngles = new Vector3(0, 0, movementAngle - 90);
        }
    }
}
