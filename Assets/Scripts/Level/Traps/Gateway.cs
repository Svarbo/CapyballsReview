using Audio;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Effect))]
    public class Gateway : MonoBehaviour
    {
        [SerializeField] private AudioClip _openSound;

        private Animator _animator;
        private Effect _audioEffect;
        private int _open = Animator.StringToHash("Open");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioEffect = GetComponent<Effect>();
        }

        private void OnMouseDown()
        {
            _audioEffect.PlayOneShot(_openSound);
            _animator.Play(_open);
        }
    }
}