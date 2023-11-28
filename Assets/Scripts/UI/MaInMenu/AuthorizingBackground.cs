using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AuthorizingBackground : MonoBehaviour
    {
        [SerializeField] private Button _agreeButton;

        private void Awake() =>
            gameObject.SetActive(PlayerAccount.IsAuthorized != true);

        private void OnEnable() =>
            _agreeButton.onClick.AddListener(LogIn);

        private void OnDisable() =>
            _agreeButton.onClick.RemoveListener(LogIn);

        public void LogIn()
        {
            PlayerAccount.Authorize();
            gameObject.SetActive(false);
        }
    }
}