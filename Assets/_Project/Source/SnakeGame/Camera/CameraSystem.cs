using SnakeGame.Common;
using UnityEngine;

namespace SnakeGame
{
    public sealed class CameraSystem : IGameStateListener
    {
        private readonly MainCamera _mainCamera;

        public CameraSystem()
        {
            _mainCamera = Object.FindObjectOfType<MainCamera>();
        }

        private void LookAtBoardCenter()
        {
            if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
            {
                return;
            }

            Vector2Int boardSize = boardService.GetSize();
            Vector3 boardCenter = new((boardSize.x - 1) / 2f, (boardSize.y - 1) / 2f);

            _mainCamera.transform.position = new Vector3(boardCenter.x, boardCenter.y, -1f);

            float screenRatio = Screen.width / (float)Screen.height;
            float targetRatio = boardSize.x / (float)boardSize.y;
 
            if (screenRatio >= targetRatio)
            {
                _mainCamera.Camera.orthographicSize = boardSize.y / 2f;
            }
            else
            {
                _mainCamera.Camera.orthographicSize = boardSize.y / 2f * (targetRatio / screenRatio);
            }
        }

        void IGameStateListener.NotifyGameSetup()
        {
            LookAtBoardCenter();
        }

        void IGameStateListener.NotifyGameBegin()
        {
        }

        void IGameStateListener.NotifyGameEnd()
        {
        }
    }
}
