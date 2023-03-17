using SnakeGame.Common;
using UnityEngine;

namespace SnakeGame
{
    public sealed class Food : MonoBehaviour, IBoardObject
    {
        public delegate void InstigatorFoundHandle(IFoodInstigator instigator);

        public event InstigatorFoundHandle OnInstigatorFound;

        private Transform _transform;
        private Vector2Int _position;

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

        private void Awake()
        {
            _transform = transform;
            _position = Vector2Int.zero;
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.gameObject.TryGetComponent(out IFoodInstigator instigator))
            {
                OnInstigatorFound?.Invoke(instigator);
            }
        }
    }
}
