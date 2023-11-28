using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private Image _mainMenu;
        [SerializeField] private Image _levelMenu;
        [SerializeField] private Image _settings;
        [SerializeField] private Image _leaderboard;

        public void EnableMainMenu()
        {
            _mainMenu.gameObject.SetActive(true);
            _levelMenu.gameObject.SetActive(false);
            _settings.gameObject.SetActive(false);
            _leaderboard.gameObject.SetActive(false);
        }

        public void EnableLevelMenu()
        {
            _levelMenu.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }

        public void EnableSettings()
        {
            _settings.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }

        public void EnableLeaderboard()
        {
            _leaderboard.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }
    }
}