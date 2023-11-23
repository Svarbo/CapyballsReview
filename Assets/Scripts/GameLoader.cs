using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    private const int LevelsCount = 24;

    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Image _finalVictoryImage;

    public void LoadMainMenu()
    {
        MainMenu.Load(0);
    }

    public void LoadLevel(int levelNumber)
    {
        Game.Load(levelNumber);
    }

    public void RestartCurrentLevel()
    {
        Game.Load(_levelLoader.LevelNumber);
    }

    public void LoadNextLevel()
    {
        if (_levelLoader.LevelNumber != LevelsCount)
        {
            int nextLevelIndex = _levelLoader.LevelNumber + 1;
            Game.Load(nextLevelIndex);
        }
        else
        {
            _finalVictoryImage.gameObject.SetActive(true);
        }
    }
}