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

        private void OnEnable() =>
            ShowOpenLevels();

        private void ShowOpenLevels()
        {
            int openLevelsNumber = PlayerPrefs.GetInt(PlayerPrefsNames.OpenLevelsNumber);

            for (int i = 0; i < openLevelsNumber; i++)
            {
                _levelButtons[i].interactable = true;
                _croses[i].gameObject.SetActive(false);
            }
        }
    }
}