using GameLoading;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinPanelView : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _menuButton;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(_sceneLoader.LoadNextLevel);
            _menuButton.onClick.AddListener(_sceneLoader.LoadMainMenu);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(_sceneLoader.LoadNextLevel);
            _menuButton.onClick.RemoveListener(_sceneLoader.LoadMainMenu);
        }
    }
}