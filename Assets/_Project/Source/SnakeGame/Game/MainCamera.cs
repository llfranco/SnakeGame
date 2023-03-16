using UnityEngine;

namespace SnakeGame.Game
{
    public sealed class MainCamera : MonoBehaviour
    {
        public Camera Camera { get; private set; }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
    }
}
