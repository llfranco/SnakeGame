using UnityEngine;

namespace SnakeGame
{
    public sealed class Board : IBoardService
    {
        private readonly object _serviceKey;
        private readonly BoardSettings _settings;
        private readonly GameObject _root;
        private readonly BoardSlot[][] _slots;

        public Board(BoardSettings settings)
        {
            _serviceKey = new object();
            _settings = settings;
            _root = new GameObject(nameof(Board));
            _slots = new BoardSlot[_settings.Size.y][];

            for (int y = 0; y < _settings.Size.y; y++)
            {
                _slots[y] = new BoardSlot[_settings.Size.x];

                for (int x = 0; x < _settings.Size.x; x++)
                {
                    _slots[y][x] = Object.Instantiate(_settings.SlotPrefab, new Vector3(x, y), Quaternion.identity, _root.transform);
                    _slots[y][x].name = $"{nameof(BoardSlot)}_{y}_{x}";
                }
            }

            ServiceLocator<IBoardService>.SetKey(_serviceKey);
            ServiceLocator<IBoardService>.SetService(this, _serviceKey);
        }

        void IBoardService.OccupyPosition(IBoardObject occupier)
        {
            _slots[occupier.Position.y][occupier.Position.x].Occupier = occupier;
        }

        void IBoardService.UnoccupyPosition(IBoardObject occupier)
        {
            _slots[occupier.Position.y][occupier.Position.x].Occupier = null;
        }

        Vector2Int IBoardService.GetSize()
        {
            return _settings.Size;
        }

        Vector2Int IBoardService.GetUnoccupiedPosition()
        {
            int row;
            int column;
            BoardSlot targetSlot;

            do
            {
                row = Random.Range(0, _settings.Size.y);
                column = Random.Range(0, _settings.Size.x);
                targetSlot = _slots[row][column];
            }
            while (targetSlot.Occupier != null);

            return new Vector2Int(row, column);
        }

        bool IBoardService.DoesPositionExist(Vector2Int position)
        {
            return position is { x: >= 0, y: >= 0 } && position.x < _settings.Size.x && position.y < _settings.Size.y;
        }
    }
}
