using SnakeGame.Common;
using UnityEngine;

namespace SnakeGame
{
    public interface IBoardService : IService
    {
        void OccupyPosition(IBoardObject occupier);

        void UnoccupyPosition(IBoardObject occupier);

        Vector2Int GetSize();

        Vector2Int GetUnoccupiedPosition();

        bool DoesPositionExist(Vector2Int position);

        bool HasAnyUnoccupiedPosition();
    }
}
