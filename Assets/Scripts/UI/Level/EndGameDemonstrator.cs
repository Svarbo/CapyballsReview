using ConstantValues;
using GameLoading;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndGameDemonstrator : MonoBehaviour
    {
        [SerializeField] private BallsContainer _ballContainer;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private Image _defeatPanel;
        [SerializeField] private Image _winPanel;
        [SerializeField] private TMP_Text _winScoreText;

        private void OnEnable() =>
            _ballContainer.IsGameEnd += DetermineOutcome;

        private void OnDisable() =>
            _ballContainer.IsGameEnd -= DetermineOutcome;

        private void DetermineOutcome()
        {
            Time.timeScale = 0;

            if(_ballContainer.Score < 0 || _ballContainer.SnairedBallsCount == _ballContainer.Score)
                DeclareDefeat();
            else
                DeclareWin();
        }

        private void DeclareWin()
        {
            TryOpenNextLevel();
            _ballContainer.UpdateLeaderboardScore();

            _winScoreText.text = _ballContainer.Score.ToString();
            _winPanel.gameObject.SetActive(true);
        }

        private void DeclareDefeat() =>
            _defeatPanel.gameObject.SetActive(true);

        private void TryOpenNextLevel()
        {
            int oldOpenLevelsNumber = PlayerPrefs.GetInt(PlayerPrefsNames.OpenLevelsNumber);

            if (oldOpenLevelsNumber <= _levelLoader.LevelNumber + 1)
                PlayerPrefs.SetInt(PlayerPrefsNames.OpenLevelsNumber, ++oldOpenLevelsNumber);
        }
    }
}