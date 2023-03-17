using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(GameSettings), fileName = nameof(GameSettings))]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField]
        private PlayerSystemSettings _playerSystemSettings;

        [SerializeField]
        private BoardSettings _boardSettings;

        [SerializeField]
        private SnakeSystemSettings _snakeSystemSettings;

        [SerializeField]
        private FoodSystemSettings _foodSystemSettings;

        public PlayerSystemSettings PlayerSystemSettings => _playerSystemSettings;

        public BoardSettings BoardSettings => _boardSettings;

        public SnakeSystemSettings SnakeSystemSettings => _snakeSystemSettings;

        public FoodSystemSettings FoodSystemSettings => _foodSystemSettings;
    }
}
