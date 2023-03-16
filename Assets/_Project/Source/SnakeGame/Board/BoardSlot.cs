using UnityEngine;

namespace SnakeGame
{
    public sealed class BoardSlot : MonoBehaviour
    {
        public IBoardObject Occupier { get; set; }
    }
}
