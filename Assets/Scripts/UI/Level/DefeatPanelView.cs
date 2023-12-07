using GameLoading;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DefeatPanelView : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_sceneLoader.RestartCurrentLevel);
            _menuButton.onClick.AddListener(_sceneLoader.LoadMainMenu);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(_sceneLoader.RestartCurrentLevel);
            _menuButton.onClick.RemoveListener(_sceneLoader.LoadMainMenu);
        }
    }
}