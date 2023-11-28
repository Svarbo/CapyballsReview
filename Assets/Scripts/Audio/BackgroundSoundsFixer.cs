using Agava.WebUtility;
using UnityEngine;

namespace Audio
{
    public class BackgroundSoundsFixer : MonoBehaviour
    {
        private const float MinVolum = 0f;
        private const float MaxVolum = 1f;

        private void OnEnable() => 
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

        private void OnDisable() => 
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? MinVolum : MaxVolum;
        }
    }
}