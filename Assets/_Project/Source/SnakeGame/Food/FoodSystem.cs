using SnakeGame.Common;
using UnityEngine;

namespace SnakeGame
{
    public sealed class FoodSystem : IGameStateListener
    {
        private readonly FoodSystemSettings _settings;

        private Food _activeFood;

        public FoodSystem(FoodSystemSettings settings)
        {
            _settings = settings;
        }

        private void SpawnFood()
        {
            _activeFood = Object.Instantiate(_settings.FoodPrefab);
            _activeFood.OnInstigatorFound += HandleActiveFoodInstigatorFound;
        }

        private void RandomizeActiveFoodPosition()
        {
            if (!ServiceLocator<IBoardService>.TryGetService(out IBoardService boardService))
            {
                return;
            }

            _activeFood.Position = boardService.GetUnoccupiedPosition();
        }

        private void HandleActiveFoodInstigatorFound(IFoodInstigator instigator)
        {
            instigator.EatFood();
            RandomizeActiveFoodPosition();
        }

        void IGameStateListener.NotifyGameSetup()
        {
            SpawnFood();
            RandomizeActiveFoodPosition();
        }

        void IGameStateListener.NotifyGameBegin()
        {
        }

        void IGameStateListener.NotifyGameEnd()
        {
        }
    }
}
