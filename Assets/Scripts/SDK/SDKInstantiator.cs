using Agava.YandexGames;
using Localization;
using System.Collections;
using UnityEngine;

namespace SDK
{
    public class SDKInstantiator : MonoBehaviour
    {
        [SerializeField] private LanguageDefiner _languageDefiner;

        private void Awake() =>
            StartCoroutine(Initialize());

        private IEnumerator Initialize()
        {
            yield return YandexGamesSdk.Initialize();

            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.StartAuthorizationPolling(1500);

            _languageDefiner.DefineLanguage();
        }
    }
}