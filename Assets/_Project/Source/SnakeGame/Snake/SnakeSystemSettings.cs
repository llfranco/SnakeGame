using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(SnakeSystemSettings), fileName = nameof(SnakeSystemSettings))]
    public sealed class SnakeSystemSettings : ScriptableObject
    {
        [SerializeField]
        private Snake _snakePrefab;

        [FormerlySerializedAs("_startingMoveDirectionPriorityList"),SerializeField]
        private List<Vector2Int> _startingDirectionPriorityList = new()
        {
            Vector2Int.down,
            Vector2Int.up,
            Vector2Int.left,
            Vector2Int.right,
        };

        public Snake SnakePrefab => _snakePrefab;

        public List<Vector2Int> StartingDirectionPriorityList => _startingDirectionPriorityList;
    }
}
