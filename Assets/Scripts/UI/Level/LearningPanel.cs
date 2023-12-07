using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LearningPanel : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;

        private void OnEnable() =>
            _exitButton.onClick.AddListener(OnExitButtonClick);

        private void OnDisable() =>
            _exitButton.onClick.RemoveListener(OnExitButtonClick);

        public void OnExitButtonClick() =>
            gameObject.SetActive(false);
    }
}