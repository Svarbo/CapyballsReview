using UnityEngine;

namespace Audio
{
    public class Ambient : SoundSource
    {
        [SerializeField] private AudioClip _audioClip;

        protected override void Awake()
        {
            base.Awake();

            Configure();
            AudioSource.Play();
        }

        private void Configure()
        {
            AudioSource.loop = true;
            AudioSource.clip = _audioClip;
        }
    }
}