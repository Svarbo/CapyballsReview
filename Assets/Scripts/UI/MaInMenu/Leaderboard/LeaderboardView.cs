using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Agava.YandexGames;
using ConstantValues;
using PlayerPrefs = UnityEngine.PlayerPrefs;

namespace UI
{
    public class LeaderboardView : MonoBehaviour
    {
        private const string RussianAnonimTranslation = "Аноним";
        private const string EnglishAnonimTranslation = "Anonymous";
        private const string TurkishAnonimTranslation = "Anonim";

        [SerializeField] private List<LeaderPlace> _leaderPlaces = new List<LeaderPlace>();
        [SerializeField] private TMP_Text _playerTopPlaceText;

        private void OnEnable() =>
            ShowLeaders();

        private void ShowLeaders()
        {
            string leaderboardName = ConstantValues.Leaderboard.Name;

            Agava.YandexGames.Leaderboard.GetEntries(leaderboardName, (result) =>
            {
                ShowFirstLeaders(result);
                ShowPlayerPlace(result);
            });
        }

        private void ShowFirstLeaders(LeaderboardGetEntriesResponse result)
        {
            string leaderName;
            int leaderScore;
            int leadersCount = _leaderPlaces.Count;

            for (int i = 0; i < leadersCount; i++)
            {
                LeaderboardEntryResponse entry = result.entries[i];

                if (entry != null)
                {
                    leaderName = GetLeaderName(entry);
                    leaderScore = GetLeaderScore(entry);

                    _leaderPlaces[i].SetLeaderData(leaderName, leaderScore);
                    _leaderPlaces[i].gameObject.SetActive(true);
                }
            }
        }

        private string GetLeaderName(LeaderboardEntryResponse entry)
        {
            string leaderName = entry.player.publicName;

            if (string.IsNullOrEmpty(leaderName))
                leaderName = SetAnonimusName();

            return leaderName;
        }

        private string SetAnonimusName()
        {
            string leaderName = "";
            int playerLanguageIndex = PlayerPrefs.GetInt(PlayerPrefsNames.LanguageIndex);

            if (playerLanguageIndex == LanguageInfo.RussianLanguageIndex)
                leaderName = RussianAnonimTranslation;
            else if (playerLanguageIndex == LanguageInfo.EnglishLanguageIndex)
                leaderName = EnglishAnonimTranslation;
            else if (playerLanguageIndex == LanguageInfo.TurkishLanguageIndex)
                leaderName = TurkishAnonimTranslation;

            return leaderName;
        }

        private int GetLeaderScore(LeaderboardEntryResponse entry) =>
            entry.score;

        private void ShowPlayerPlace(LeaderboardGetEntriesResponse result) =>
            _playerTopPlaceText.text = result.userRank.ToString();
    }
}