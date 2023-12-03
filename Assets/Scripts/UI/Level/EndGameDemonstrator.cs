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
        [SerializeField] private BallsContainer _ballsContainer;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private Image _defeatPanel;
        [SerializeField] private Image _winPanel;
        [SerializeField] private TMP_Text _winScoreText;

        private void OnEnable() =>
            _ballsContainer.IsGameEnd += DetermineOutcome;

        private void OnDisable() =>
            _ballsContainer.IsGameEnd -= DetermineOutcome;

        private void DetermineOutcome()
        {
            if(_ballsContainer.Score < 0 || _ballsContainer.SnairedBallsCount == _ballsContainer.Score)
                DeclareDefeat();
            else
                DeclareWin();

            Time.timeScale = 0;
        }

        private void DeclareWin()
        {
            TryOpenNextLevel();
            _ballsContainer.UpdateLeaderboardScore();

            _winScoreText.text = _ballsContainer.Score.ToString();
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