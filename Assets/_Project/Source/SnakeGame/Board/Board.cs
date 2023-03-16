using UnityEngine;

namespace SnakeGame
{
    public sealed class Board : MonoBehaviour, IBoardService
    {
        private static readonly object ServiceKey = new();

        [SerializeField]
        private BoardSettings _settings;

        private BoardSlot[,] _slots;

        public void CreateSlots()
        {
            int rows = _settings.Size.y;
            int columns = _settings.Size.x;

            _slots = new BoardSlot[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    _slots[row, column] = Instantiate(_settings.SlotPrefab, new Vector3(column, row), Quaternion.identity, transform);
                    _slots[row, column].name = $"{nameof(BoardSlot)}_{row}_{column}";
                }
            }
        }

        public void OccupyPosition(IBoardObject occupier)
        {
            _slots[occupier.Position.y, occupier.Position.x].Occupier = occupier;
        }

        public void UnoccupyPosition(IBoardObject occupier)
        {
            _slots[occupier.Position.y, occupier.Position.x].Occupier = null;
        }

        public Vector2Int GetSize()
        {
            return _settings.Size;
        }

        public Vector2Int GetUnoccupiedPosition()
        {
            int row;
            int column;
            BoardSlot targetSlot;

            do
            {
                row = Random.Range(0, _settings.Size.y);
                column = Random.Range(0, _settings.Size.x);
                targetSlot = _slots[row, column];
            }
            while (targetSlot.Occupier != null);

            return new Vector2Int(row, column);
        }

        public bool DoesPositionExist(Vector2Int position)
        {
            return position is { x: >= 0, y: >= 0 } && position.x < _settings.Size.x && position.y < _settings.Size.y;
        }

        private void Awake()
        {
            ServiceLocator<IBoardService>.SetKey(ServiceKey);
            ServiceLocator<IBoardService>.SetService(this, ServiceKey);
        }
    }
}
