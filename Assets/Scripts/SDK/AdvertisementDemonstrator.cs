using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace SDK
{
    public class AdvertisementDemonstrator : MonoBehaviour
    {
        [SerializeField] private int _advertisementDemonstrationFrequency = 3;
        [SerializeField] private Image _advertisementPanel;

        private int _attemptCount;

        private void Awake()
        {
            IncreaseAttemptsCount();
            TryShow();
        }

        public void OnStartPlayButtonClick()
        {
            _advertisementPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private bool TryShow()
        {
            if (_attemptCount % _advertisementDemonstrationFrequency == 0)
            {
                StopGame();
                Show();

                return true;
            }
            else
            {
                _advertisementPanel.gameObject.SetActive(false);

                return false;
            }
        }

        private void IncreaseAttemptsCount()
        {
            _attemptCount = UnityEngine.PlayerPrefs.GetInt("AttemptCount");
            _attemptCount++;
            UnityEngine.PlayerPrefs.SetInt("AttemptCount", _attemptCount);
        }

        private void StopGame() =>
            Time.timeScale = 0;

        private void Show() =>
            InterstitialAd.Show();
    }
}