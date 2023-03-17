using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(GameSettings), fileName = nameof(GameSettings))]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField]
        private BoardSettings _boardSettings;

        [SerializeField]
        private FoodSystemSettings _foodSystemSettings;

        [SerializeField]
        private List<PlayerActionMap> _playerActionMaps;

        [SerializeField]
        private Snake _snakePrefab;

        public BoardSettings BoardSettings => _boardSettings;

        public FoodSystemSettings FoodSystemSettings => _foodSystemSettings;

        public List<PlayerActionMap> PlayerActionMaps => _playerActionMaps;

        public Snake SnakePrefab => _snakePrefab;
    }
}
