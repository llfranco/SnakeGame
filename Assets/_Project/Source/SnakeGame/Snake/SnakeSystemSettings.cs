using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(SnakeSystemSettings), fileName = nameof(SnakeSystemSettings))]
    public sealed class SnakeSystemSettings : ScriptableObject
    {
        [SerializeField]
        private Snake _snakePrefab;

        public Snake SnakePrefab => _snakePrefab;
    }
}
