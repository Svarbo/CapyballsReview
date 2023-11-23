using UnityEngine;
using System.Collections;
using Agava.YandexGames;

public class SDKInstantiator : MonoBehaviour
{
    [SerializeField] private SoundsVolume _soundsVolume;
    [SerializeField] private LanguageDefiner _languageDefiner;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        PlayerAccount.AuthorizedInBackground += OnAuthorizedInBackground;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);

        _soundsVolume.SetVolumeValues();
        _languageDefiner.TryDefineLanguage();
    }

    private void OnDestroy()
    {
        PlayerAccount.AuthorizedInBackground -= OnAuthorizedInBackground;
    }

    private void OnAuthorizedInBackground()
    {
        Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
    }
}