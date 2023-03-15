using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/Board Settings", fileName = nameof(BoardSettings))]
    public sealed class BoardSettings : ScriptableObject
    {
        [SerializeField]
        private Vector2Int _size;

        [SerializeField]
        private GameObject _tilePrefab;

        public Vector2Int Size => _size;

        public GameObject TilePrefab => _tilePrefab;
    }
}
