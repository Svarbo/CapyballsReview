using Agava.YandexGames;
using ConstantValues;
using UnityEngine;
using PlayerPrefs = UnityEngine.PlayerPrefs;

namespace Localization
{
    public class LanguageDefiner : MonoBehaviour
    {
        [SerializeField] private LanguageData _languageData;

        public void DefineLanguage()
        {
            bool languageWasChanged = _languageData.LanguageWasChanged;

            if (languageWasChanged != true)
                SetLanguage();
        }

        private void SetLanguage()
        {
            string languageDesignation = YandexGamesSdk.Environment.i18n.lang;
            string playerPrefsLanguageIndex = PlayerPrefsNames.LanguageIndex;

            switch (languageDesignation)
            {
                case LanguageInfo.RussianDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.RussianLanguageIndex);
                    break;
                case LanguageInfo.BelarusianDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.RussianLanguageIndex);
                    break;
                case LanguageInfo.KazakhDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.RussianLanguageIndex);
                    break;
                case LanguageInfo.UkrainianDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.RussianLanguageIndex);
                    break;
                case LanguageInfo.UzbekDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.RussianLanguageIndex);
                    break;
                case LanguageInfo.TurkishDesignation:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.TurkishLanguageIndex);
                    break;
                default:
                    PlayerPrefs.SetInt(playerPrefsLanguageIndex, LanguageInfo.EnglishLanguageIndex);
                    break;
            }

            PlayerPrefs.Save();
        }
    }
}