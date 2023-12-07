using ConstantValues;
using GameLoading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> _levelButtons = new List<Button>();
        [SerializeField] private List<Image> _croses = new List<Image>();
        [SerializeField] private SceneLoader _sceneLoader;

        private List<LevelButtonListener> _levelButtonsListeners = new List<LevelButtonListener>();

        private void OnEnable()
        {
            SubscribeButtons();
            ShowOpenLevels();
        }

        private void OnDisable() =>
            UnsubscribeButtons();

        private void ShowOpenLevels()
        {
            int openLevelsNumber = PlayerPrefs.GetInt(PlayerPrefsNames.OpenLevelsNumber);

            for (int i = 0; i < openLevelsNumber; i++)
            {
                _levelButtons[i].interactable = true;
                _croses[i].gameObject.SetActive(false);
            }
        }

        private void SubscribeButtons()
        {
            LevelButtonListener levelButtonListener;

            for (int i = 0; i < _levelButtons.Count; i++)
            {
                levelButtonListener = new LevelButtonListener(_levelButtons[i],() => _sceneLoader.LoadLevel(i));
                _levelButtonsListeners.Add(levelButtonListener);
                levelButtonListener.Create();
            }
        }

        private void UnsubscribeButtons()
        {
            foreach(LevelButtonListener levelButtonListener in _levelButtonsListeners)
                levelButtonListener.Destroy();

            _levelButtonsListeners.Clear();
        }
    }
}