using UnityEngine;

namespace SnakeGame
{
    public sealed class Food : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (!otherCollider.gameObject.TryGetComponent(out ISnakeBodyPart snakeBodyPart))
            {
                return;
            }

            snakeBodyPart.Snake.IncreaseBodySize();
            Destroy(gameObject);
        }
    }
}
