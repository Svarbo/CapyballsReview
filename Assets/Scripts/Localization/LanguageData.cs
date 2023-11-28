using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(menuName = "Localization/LanguageData", fileName = "LanguageData")]
    public class LanguageData : ScriptableObject
    {
        [SerializeField] private bool _languageWasChanged;

        public bool LanguageWasChanged => _languageWasChanged;

        public void SetLanguageWasChanged(bool value) => 
            _languageWasChanged = value;
    }
}