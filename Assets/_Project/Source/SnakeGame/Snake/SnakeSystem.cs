using SnakeGame.Common;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public sealed class SnakeSystem : ISnakeService, IGameStateListener
    {
        public delegate void SnakesHandler();

        public event SnakesHandler OnSnakeMoved;
        public event SnakesHandler OnSnakesDied;

        private readonly object _serviceKey;
        private readonly SnakeSystemSettings _settings;
        private readonly List<Snake> _activeSnakes;

        public SnakeSystem(SnakeSystemSettings settings)
        {
            _serviceKey = new object();
            _settings = settings;
            _activeSnakes = new List<Snake>();

            ServiceLocator<ISnakeService>.SetKey(_serviceKey);
            ServiceLocator<ISnakeService>.SetService(this, _serviceKey);
        }

        ~SnakeSystem()
        {
            ServiceLocator<ISnakeService>.SetService(null, _serviceKey);
        }

        private void HandleSnakeMove(Snake sender)
        {
            OnSnakeMoved?.Invoke();
        }

        private void HandleSnakeDeath(Snake sender)
        {
            sender.StopMoving();
            sender.SelfDestroy();

            _activeSnakes.Remove(sender);

            if (_activeSnakes.Count == 0)
            {
                OnSnakesDied?.Invoke();
            }
        }

        ISnake ISnakeService.SpawnSnake()
        {
            if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
            {
                return default;
            }

            Snake snake = Object.Instantiate(_settings.SnakePrefab, Vector3.zero, Quaternion.identity);
            snake.OnMove += HandleSnakeMove;
            snake.OnDeath += HandleSnakeDeath;
            snake.CreateHead();
            snake.SetPosition(boardService.GetUnoccupiedPosition());

            _activeSnakes.Add(snake);

            return snake;
        }

        void IGameStateListener.NotifyGameSetup()
        {
        }

        void IGameStateListener.NotifyGameBegin()
        {
            foreach (Snake snake in _activeSnakes)
            {
                snake.StartMoving();
            }
        }

        void IGameStateListener.NotifyGameEnd()
        {
            if (_activeSnakes.Count == 0)
            {
                return;
            }

            foreach (Snake snake in _activeSnakes)
            {
                snake.StopMoving();
            }
        }
    }
}
