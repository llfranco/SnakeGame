using UnityEngine;

namespace SnakeGame
{
    public sealed class Board : MonoBehaviour, IBoardService
    {
        private static readonly object ServiceKey = new();

        [SerializeField]
        private BoardSettings _settings;

        private BoardSlot[,] _tiles;

        public void OccupyPosition(IBoardObject occupier)
        {
            _tiles[occupier.Position.y, occupier.Position.x].Occupier = occupier;
        }

        public void UnoccupyPosition(IBoardObject occupier)
        {
            _tiles[occupier.Position.y, occupier.Position.x].Occupier = null;
        }

        private void Awake()
        {
            CreateTiles();

            ServiceLocator<IBoardService>.SetKey(ServiceKey);
            ServiceLocator<IBoardService>.SetService(this, ServiceKey);
        }

        private void CreateTiles()
        {
            int rows = _settings.Size.y;
            int columns = _settings.Size.x;

            _tiles = new BoardSlot[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    _tiles[row, column] = Instantiate(_settings.SlotPrefab, new Vector3(row, column), Quaternion.identity, transform);
                }
            }
        }
    }
}
