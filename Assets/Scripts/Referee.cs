using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _defeatPanel;
    [SerializeField] private Image _winPanel;
    [SerializeField] private TMP_Text _winScoreText;
    [SerializeField] private LevelLoader _levelLoader;

    private int _currentScore = 0;

    private void OnEnable()
    {
        _player.BallsCountDecreased += CheckDefeat;
    }

    private void OnDisable()
    {
        _player.BallsCountDecreased -= CheckDefeat;
    }

    private void CheckDefeat()
    {
        if (_player.BallsCount <= 0)
            DeclareDefeat();
    }

    public void ReduceScore(int reward)
    {
        _currentScore += reward;
    }

    public void DeclareDefeat()
    {
        Time.timeScale = 0;

        _defeatPanel.gameObject.SetActive(true);
    }

    public void CheckWin()
    {
        if (_currentScore > 0)
            DeclareWin();
        else
            DeclareDefeat();
    }

    private void DeclareWin()
    {
        Time.timeScale = 0;

        TryOpenNextLevel();

        _winScoreText.text = _currentScore.ToString();
        _winPanel.gameObject.SetActive(true);

        _player.ReduceScore(_currentScore);
    }

    private void TryOpenNextLevel()
    {
        int oldOpenLevelsNumber = PlayerPrefs.GetInt("OpenLevelsNumber");

        if (oldOpenLevelsNumber <= _levelLoader.LevelNumber + 1)
            PlayerPrefs.SetInt("OpenLevelsNumber", oldOpenLevelsNumber + 1);

        PlayerPrefs.Save();
    }
}