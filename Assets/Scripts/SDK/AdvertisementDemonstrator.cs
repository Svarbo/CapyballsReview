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

            if (_attemptCount % _advertisementDemonstrationFrequency == 0)
                Demonstrate();
            else
                _advertisementPanel.gameObject.SetActive(false);
        }

        public void OnStartPlayButtonClick()
        {
            _advertisementPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private void IncreaseAttemptsCount()
        {
            _attemptCount = UnityEngine.PlayerPrefs.GetInt("AttemptCount");
            _attemptCount++;
            UnityEngine.PlayerPrefs.SetInt("AttemptCount", _attemptCount);
        }

        private void Demonstrate()
        {
            Time.timeScale = 0;
            InterstitialAd.Show();
        }
    }
}