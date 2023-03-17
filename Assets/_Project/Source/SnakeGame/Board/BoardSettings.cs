using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(BoardSettings), fileName = nameof(BoardSettings))]
    public sealed class BoardSettings : ScriptableObject
    {
        [SerializeField]
        private Vector2Int _size;

        [SerializeField]
        private BoardSlot _slotPrefab;

        public Vector2Int Size => _size;

        public BoardSlot SlotPrefab => _slotPrefab;
    }
}
