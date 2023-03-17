using SnakeGame.Common;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public sealed class Snake : MonoBehaviour, ISnake
    {
        public delegate void SnakeHandler(Snake sender);

        public delegate bool PositionValidatorHandler(Snake caller, Vector2Int position);

        public event SnakeHandler OnMove;
        public event SnakeHandler OnDeath;

        [SerializeField]
        private SnakeSettings _settings;

        private Vector2Int _direction;
        private SnakeBodyPart _head;
        private List<SnakeBodyPart> _bodyParts;
        private List<TransformRecord> _headTransformRecords;
        private PositionValidatorHandler _positionValidatorHandler;

        public void CreateHead()
        {
            _head = Instantiate(_settings.HeadPrefab);
            _head.Snake = this;
        }

        public void SetPositionValidatorHandler(PositionValidatorHandler value)
        {
            _positionValidatorHandler = value;
        }

        public void SetPosition(Vector2Int position)
        {
            _head.Position = position;
        }

        public void StartMoving()
        {
            InvokeRepeating(nameof(Move), 0f, _settings.MovementRate);
        }

        public void StopMoving()
        {
            CancelInvoke(nameof(Move));
        }

        public void SelfDestroy()
        {
            if (_settings.SelfDestroyDelay > 0f)
            {
                Invoke(nameof(DelayedSelfDestroy), _settings.SelfDestroyDelay);
            }
            else
            {
                DelayedSelfDestroy();
            }
        }

        public List<Vector2Int> GetOccupyingPositions()
        {
            List<Vector2Int> positions = new()
            {
                _head.Position,
            };

            foreach (SnakeBodyPart bodyPart in _bodyParts)
            {
                positions.Add(bodyPart.Position);
            }

            return positions;
        }

        private void Awake()
        {
            _direction = Vector2Int.down;
            _bodyParts = new List<SnakeBodyPart>();
            _headTransformRecords = new List<TransformRecord>();
        }

        private void CreateBodyPart()
        {
            SnakeBodyPart bodyPart = Instantiate(_settings.BodyPartPrefab);
            bodyPart.Snake = this;
            _bodyParts.Add(bodyPart);
        }

        private void UpdateBodyPartPositions()
        {
            for (int i = 0; i < _bodyParts.Count; i++)
            {
                _bodyParts[i].Position = _headTransformRecords[i].Position;
                _bodyParts[i].Rotation = _headTransformRecords[i].Rotation;
            }
        }

        private void Move()
        {
            Vector2Int nextHeadPosition = _head.Position + _direction * _settings.MovementSpeed;

            if (DieIfInvalidPosition(nextHeadPosition))
            {
                return;
            }

            _headTransformRecords.Insert(0, new TransformRecord
            {
                Position = _head.Position,
                Rotation = _head.Rotation,
            });

            if (_headTransformRecords.Count > _bodyParts.Count + 1)
            {
                _headTransformRecords.RemoveAt(_headTransformRecords.Count - 1);
            }

            UpdateBodyPartPositions();

            float movementAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

            if (movementAngle < 0)
            {
                movementAngle += 360;
            }

            _head.Rotation = Quaternion.Euler(new Vector3(0, 0, movementAngle - 90));
            _head.Position = nextHeadPosition;

            OnMove?.Invoke(this);
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
        }

        private bool DieIfInvalidPosition(Vector2Int position)
        {
            if (_positionValidatorHandler == null || _positionValidatorHandler.Invoke(this, position))
            {
                return false;
            }

            StopMoving();
            Die();

            return true;
        }

        private void DelayedSelfDestroy()
        {
            if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
            {
                return;
            }

            boardService.UnoccupyPosition(_head);
            Destroy(_head.gameObject);

            foreach (SnakeBodyPart bodyPart in _bodyParts)
            {
                boardService.UnoccupyPosition(bodyPart);
                Destroy(bodyPart.gameObject);
            }

            Destroy(gameObject);
        }

        void ISnake.ChangeMovementDirection(Vector2Int direction)
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

        void ISnake.IncreaseBodySize()
        {
            CreateBodyPart();
            UpdateBodyPartPositions();
        }
    }
}
