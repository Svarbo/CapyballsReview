using ConstantValues;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    [RequireComponent(typeof(ToggleGroup))]
    public class LanguagesChanger : MonoBehaviour
    {
        private ToggleGroup _toggleGroup;
        private List<Toggle> _toggles = new List<Toggle>();
        private LanguageData _settingsData;

        private void Awake()
        {
            _toggleGroup = GetComponent<ToggleGroup>();
            _toggles = _toggleGroup.ActiveToggles().ToList();

            SetCurrentToggleActive();
        }

        private void OnEnable()
        {
            foreach (Toggle toggle in _toggles)
                toggle.onValueChanged.AddListener(ChangeLanguage);
        }

        private void OnDisable()
        {
            foreach (Toggle toggle in _toggles)
                toggle.onValueChanged.RemoveListener(ChangeLanguage);
        }

        private void ChangeLanguage(bool isActive)
        {
            if (isActive)
            {
                Toggle activeToggle = _toggleGroup.GetFirstActiveToggle();
                int languageIndex = activeToggle.transform.GetSiblingIndex();

                PlayerPrefs.SetInt(PlayerPrefsNames.LanguageIndex, languageIndex);
                _settingsData.SetLanguageWasChanged(true);
            }
        }

        private void SetCurrentToggleActive()
        {
            int activeToggleIndex = PlayerPrefs.GetInt(PlayerPrefsNames.LanguageIndex);
            _toggles[activeToggleIndex].isOn = true;
        }
    }
}