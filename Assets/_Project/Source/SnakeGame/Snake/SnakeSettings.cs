using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(SnakeSettings), fileName = nameof(SnakeSettings))]
    public sealed class SnakeSettings : ScriptableObject
    {
        [SerializeField]
        private SnakeBodyPart _headPrefab;

        [SerializeField]
        private SnakeBodyPart _bodyPartPrefab;

        [SerializeField]
        private int _movementSpeed = 1;

        [SerializeField]
        private float _movementRate = 0.125f;

        [SerializeField]
        private float _selfDestroyDelay = 0.1f;

        public SnakeBodyPart HeadPrefab => _headPrefab;

        public SnakeBodyPart BodyPartPrefab => _bodyPartPrefab;

        public int MovementSpeed => _movementSpeed;

        public float MovementRate => _movementRate;

        public float SelfDestroyDelay => _selfDestroyDelay;
    }
}
