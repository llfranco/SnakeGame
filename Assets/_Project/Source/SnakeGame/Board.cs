using UnityEngine;

namespace SnakeGame
{
    public sealed class Board : MonoBehaviour, IBoardService
    {
        private static object _serviceKey = new();

        [SerializeField]
        private BoardSettings _settings;

        private GameObject[,] _tiles;

        private void Awake()
        {
            CreateTiles();

            ServiceLocator<IBoardService>.SetKey(_serviceKey);
            ServiceLocator<IBoardService>.SetService(this, _serviceKey);
        }

        private void CreateTiles()
        {
            int rows = _settings.Size.y;
            int columns = _settings.Size.x;

            _tiles = new GameObject[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    _tiles[row, column] = Instantiate(_settings.TilePrefab, new Vector3(row, column), Quaternion.identity, transform);
                }
            }
        }
    }
}
