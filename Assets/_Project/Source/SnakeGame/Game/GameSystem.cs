﻿using SnakeGame.Common;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public sealed class GameSystem : MonoBehaviour, IGameService
    {
        public event GameHandler OnLateGameEnd;

        private readonly object _serviceKey = new();

        [SerializeField]
        private GameSettings _settings;

        private CameraSystem _cameraSystem;
        private PlayerSystem _playerSystem;
        private Board _board;
        private SnakeSystem _snakeSystem;
        private FoodSystem _foodSystem;
        private List<IGameStateListener> _gameStateListeners;

        private void Awake()
        {
            _cameraSystem = new CameraSystem();
            _playerSystem = new PlayerSystem(_settings.PlayerSystemSettings);
            _board = new Board(_settings.BoardSettings);
            _snakeSystem = new SnakeSystem(_settings.SnakeSystemSettings);
            _foodSystem = new FoodSystem(_settings.FoodSystemSettings);
            _gameStateListeners = new List<IGameStateListener>
            {
                _cameraSystem,
                _playerSystem,
                _snakeSystem,
                _foodSystem,
            };

            ServiceLocator<IGameService>.SetKey(_serviceKey);
            ServiceLocator<IGameService>.SetService(this, _serviceKey);
        }

        private void Start()
        {
            foreach (IGameStateListener listener in _gameStateListeners)
            {
                listener.NotifyGameSetup();
            }
        }

        private void OnDestroy()
        {
            _cameraSystem = null;
            _playerSystem = null;
            _board = null;
            _snakeSystem = null;
            _foodSystem = null;
            _gameStateListeners.Clear();

            ServiceLocator<IGameService>.SetService(null, _serviceKey);
        }

        private void EndGame()
        {
            _snakeSystem.OnSnakeMoved -= HandleSnakeMoved;
            _snakeSystem.OnSnakesDied -= HandleSnakesDied;

            foreach (IGameStateListener listener in _gameStateListeners)
            {
                listener.NotifyGameEnd();
            }

            OnLateGameEnd?.Invoke();
        }

        private void HandleSnakeMoved()
        {
        }

        private void HandleSnakesDied()
        {
            EndGame();
        }

        void IGameService.BeginGame()
        {
            foreach (IGameStateListener listener in _gameStateListeners)
            {
                listener.NotifyGameBegin();
            }

            _snakeSystem.OnSnakeMoved += HandleSnakeMoved;
            _snakeSystem.OnSnakesDied += HandleSnakesDied;
        }
    }
}
