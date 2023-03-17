using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public sealed class GameSystem : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _settings;

        private CameraSystem _cameraSystem;
        private Board _board;
        private FoodSystem _foodSystem;
        private List<IGameStateListener> _gameStateListeners;

        private void Awake()
        {
            _cameraSystem = new CameraSystem();
            _board = new Board(_settings.BoardSettings);
            _foodSystem = new FoodSystem(_settings.FoodSystemSettings);
            _gameStateListeners = new List<IGameStateListener>
            {
                _cameraSystem,
                _foodSystem,
            };

            foreach (PlayerActionMap actionMap in _settings.PlayerActionMaps)
            {
                Snake snake = Instantiate(_settings.SnakePrefab, Vector3.zero, Quaternion.identity);
                PlayerController controller = new(actionMap, snake);

                snake.OnDeath += HandleSnakeDeath;

                _gameStateListeners.Add(controller);
                _gameStateListeners.Add(snake);
            }
        }

        private void Start()
        {
            foreach (IGameStateListener listener in _gameStateListeners)
            {
                listener.NotifyGameSetup();
            }

            foreach (IGameStateListener listener in _gameStateListeners)
            {
                listener.NotifyGameBegin();
            }
        }

        private void HandleSnakeDeath(Snake sender)
        {
        }
    }
}
