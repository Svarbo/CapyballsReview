using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour
{
    [SerializeField] private AudioClip _ouchSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _snakeSound;
    [SerializeField] private AudioClip _transitionsSound;
    [SerializeField] private AudioClip _addSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOuchSound()
    {
        _audioSource.PlayOneShot(_ouchSound);
    }

    public void PlaySnakeHitSound()
    {
        _audioSource.PlayOneShot(_hitSound);
        _audioSource.PlayOneShot(_snakeSound);
    }

    public void PlayTransitionSound()
    {
        _audioSource.PlayOneShot(_transitionsSound);
    }

    public void PlayAddSound()
    {
        _audioSource.PlayOneShot(_addSound);
    }
}