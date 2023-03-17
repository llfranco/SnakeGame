using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SnakeGame.UI
{
    public sealed class MainMenu : BaseMenu
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private string _gameSceneName;

        private void Awake()
        {
            _playButton.onClick.AddListener(HandlePlayButtonClick);

            Show();
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
        }

        private void HandlePlayButtonClick()
        {
            SceneManager.LoadScene(_gameSceneName);
        }
    }
}
