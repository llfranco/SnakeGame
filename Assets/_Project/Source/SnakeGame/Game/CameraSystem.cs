using UnityEngine;

namespace SnakeGame.Game
{
    public sealed class CameraSystem : MonoBehaviour
    {
        private MainCamera _mainCamera;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<MainCamera>();
        }

        private void Start()
        {
            if (_mainCamera)
            {
                LookAtBoardCenter();
            }
        }

        private void LookAtBoardCenter()
        {
            if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
            {
                return;
            }

            Vector2Int boardSize = boardService.GetSize();
            Vector3 boardCenter = new((boardSize.x - 1) / 2f, (boardSize.y - 1) / 2f, -10f);

            _mainCamera.transform.position = boardCenter;
        }
    }
}
