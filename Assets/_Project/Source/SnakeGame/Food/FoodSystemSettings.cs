using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(FoodSystemSettings), fileName = nameof(FoodSystemSettings))]
    public sealed class FoodSystemSettings : ScriptableObject
    {
        [SerializeField]
        private Food _foodPrefab;

        public Food FoodPrefab => _foodPrefab;
    }
}
