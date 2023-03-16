namespace SnakeGame
{
    public interface IBoardService : IService
    {
        void OccupyPosition(IBoardObject occupier);

        void UnoccupyPosition(IBoardObject occupier);
    }
}
