using UnityEngine;

namespace SnakeGame
{
    public interface IService
    {
    }

    public interface IBoardService : IService
    {
    }

    public static class ServiceLocator<T> where T : IService
    {
        private static object _key;
        private static T _service;

        public static void SetKey(object key)
        {
            _key = key;
        }

        public static void SetService(T service, object key)
        {
            if (key != _key)
            {
                return;
            }

            _service = service;
        }
    }

    public sealed class Board : MonoBehaviour, IBoardService
    {
        [SerializeField]
        private BoardSettings _settings;

        private GameObject[,] _tiles;

        private void Awake()
        {
            CreateTiles();
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
