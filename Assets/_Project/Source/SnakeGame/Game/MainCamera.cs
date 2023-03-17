using UnityEngine;

namespace SnakeGame
{
    public sealed class MainCamera : MonoBehaviour
    {
        private Camera _camera;

        public Camera Camera
        {
            get
            {
                return _camera ??= GetComponent<Camera>();
            }
        }
    }
}
