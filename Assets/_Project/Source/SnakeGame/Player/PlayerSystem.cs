using SnakeGame.Common;
using System.Collections.Generic;

namespace SnakeGame
{
    public sealed class PlayerSystem : IGameStateListener
    {
        private readonly PlayerSystemSettings _settings;
        private readonly List<PlayerController> _activeControllers;

        public PlayerSystem(PlayerSystemSettings settings)
        {
            _settings = settings;
            _activeControllers = new List<PlayerController>();
        }

        private void CreatePlayers()
        {
            if (!ServiceLocator<ISnakeService>.TryGetService(out ISnakeService snakeService))
            {
                return;
            }

            foreach (PlayerActionMap actionMap in _settings.PlayerActionMaps)
            {
                ISnake snake = snakeService.SpawnSnake();
                PlayerController controller = new(actionMap, snake);

                _activeControllers.Add(controller);
            }
        }

        void IGameStateListener.NotifyGameSetup()
        {
            CreatePlayers();
        }

        void IGameStateListener.NotifyGameBegin()
        {
            foreach (PlayerController controller in _activeControllers)
            {
                controller.EnableInputs();
            }
        }

        void IGameStateListener.NotifyGameEnd()
        {
            foreach (PlayerController controller in _activeControllers)
            {
                controller.DisableInputs();
            }
        }
    }
}
