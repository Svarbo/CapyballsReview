using ConstantValues;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SoundSource : MonoBehaviour
    {
        protected AudioSource AudioSource;

        protected virtual void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            SetVolume();
        }

        public void SetVolume()
        {
            float volumeValue = PlayerPrefs.GetFloat(PlayerPrefsNames.Volume);
            AudioSource.volume = volumeValue;
        }
    }
}