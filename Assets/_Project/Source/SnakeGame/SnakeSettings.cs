using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/Snake Settings", fileName = nameof(SnakeSettings))]
    public sealed class SnakeSettings : ScriptableObject
    {
        [SerializeField]
        private SnakeBodyPart _bodyPartPrefab;

        [SerializeField]
        private int _movementSpeed = 1;

        [SerializeField]
        private float _startMovingDelay = 1f;

        [SerializeField]
        private float _movementRate = 0.125f;

        public SnakeBodyPart BodyPartPrefab => _bodyPartPrefab;

        public int MovementSpeed => _movementSpeed;

        public float StartMovingDelay => _startMovingDelay;

        public float MovementRate => _movementRate;
    }
}
