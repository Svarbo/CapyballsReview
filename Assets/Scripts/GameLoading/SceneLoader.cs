using IJunior.TypedScenes;
using LevelCreation;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoading
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Data _currentData;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private Image _finalVictoryImage;

        public void LoadMainMenu() =>
            MainMenu.Load(0);

        public void LoadLevel(int levelNumber) =>
            Game.Load(levelNumber);

        public void RestartCurrentLevel() =>
            Game.Load(_levelLoader.LevelNumber);

        public void LoadNextLevel()
        {
            if (_levelLoader.LevelNumber !=  24)//_currentData.PlatformsCount)
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
}