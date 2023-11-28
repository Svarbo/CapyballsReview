using UnityEngine;

namespace Audio
{
    public class Effect : SoundSource
    {
        public void PlayOneShot(AudioClip audioClip) =>
            AudioSource.PlayOneShot(audioClip);
    }
}