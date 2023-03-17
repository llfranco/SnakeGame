using UnityEngine;

namespace SnakeGame.UI
{
    public abstract class BaseMenu : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        protected void Show()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }

        protected void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }
}
