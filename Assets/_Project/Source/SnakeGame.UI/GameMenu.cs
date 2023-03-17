using SnakeGame.Common;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SnakeGame.UI
{
    public sealed class GameMenu : BaseMenu
    {
        [SerializeField]
        private Button _restartGameButton;

        [SerializeField]
        private TextMeshProUGUI _pressButtonText;

        [SerializeField]
        private InputAction _pressButtonAction;

        private void Awake()
        {
            _pressButtonText.gameObject.SetActive(true);
            _restartGameButton.gameObject.SetActive(false);
            _restartGameButton.onClick.AddListener(HandleRestartGameButtonClick);
            _pressButtonAction.performed += HandlePressButtonInputActionPerformed;
            _pressButtonAction.Enable();

            Show();
        }

        private void Start()
        {
            if (ServiceLocator<IGameService>.TryGetService(out IGameService gameService))
            {
                gameService.OnLateGameEnd += HandleGameServiceLateGameEnd;
            }
        }

        private void OnDestroy()
        {
            if (ServiceLocator<IGameService>.TryGetService(out IGameService gameService))
            {
                gameService.OnLateGameEnd -= HandleGameServiceLateGameEnd;
            }

            _pressButtonAction.performed -= HandlePressButtonInputActionPerformed;
            _pressButtonAction.Enable();
            _restartGameButton.onClick.RemoveAllListeners();
        }

        private void HandlePressButtonInputActionPerformed(InputAction.CallbackContext context)
        {
            if (!ServiceLocator<IGameService>.TryGetService(out IGameService gameService))
            {
                return;
            }

            gameService.BeginGame();
            Hide();
        }

        private void HandleRestartGameButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void HandleGameServiceLateGameEnd()
        {
            _restartGameButton.gameObject.SetActive(true);
            _pressButtonText.gameObject.SetActive(false);

            Show();
        }
    }
}
