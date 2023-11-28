using ConstantValues;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> _levelButtons = new List<LevelButton>();

        private void OnEnable() =>
            ShowOpenLevels();

        private void ShowOpenLevels()
        {
            int openLevelsNumber = PlayerPrefs.GetInt(PlayerPrefsNames.OpenLevelsNumber);

            for (int i = 0; i < openLevelsNumber; i++)
                _levelButtons[i].Draw();
        }
    }
}