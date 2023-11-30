using ConstantValues;
using GameLoading;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> _levelButtons = new List<LevelButton>();
        [SerializeField] private SceneLoader _sceneLoader;

        private void OnEnable() =>
            ShowOpenLevels();

        private void ShowOpenLevels()
        {
            int openLevelsNumber = PlayerPrefs.GetInt(PlayerPrefsNames.OpenLevelsNumber);

            for (int i = 0; i < openLevelsNumber; i++)
                _levelButtons[i].Draw();
        }

        private void Subscribe()
        {
            for(int i = 0; i < _levelButtons.Count; i++)
                _levelButtons[i].onClick.AddListener(() => _sceneLoader.LoadLevel(i));
        }

        private void Unsubscribe()
        {
            for (int i = 0; i < _levelButtons.Count; i++)
                _levelButtons[i].onClick.RemoveAllListeners();
        }
    }
}