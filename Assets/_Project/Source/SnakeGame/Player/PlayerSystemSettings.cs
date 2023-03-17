using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    [CreateAssetMenu(menuName = "SnakeGame/" + nameof(PlayerSystemSettings), fileName = nameof(PlayerSystemSettings))]
    public sealed class PlayerSystemSettings : ScriptableObject
    {
        [SerializeField]
        private List<PlayerActionMap> _playerActionMaps;

        public List<PlayerActionMap> PlayerActionMaps => _playerActionMaps;
    }
}
