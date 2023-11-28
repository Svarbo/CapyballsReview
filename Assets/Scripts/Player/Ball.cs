using Audio;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Effect))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private AudioClip _appearingSound;
        [SerializeField] private AudioClip _desappearingSound;

        private Effect _audioEffect;
        private Vector3 _target;
        private float _duration = 0.8f;
        private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

        private void Awake() =>
            _audioEffect = GetComponent<Effect>();

        //private void OnEnable() =>
        //    _audioEffect.PlayOneShot(_appearingSound);

        //private void OnDisable() =>
        //    _audioEffect.PlayOneShot(_desappearingSound);

        public void Forward(Vector3 target)
        {
            _target = target;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            float elapsed = 0;
            Vector3 startPosition = transform.position;
            Vector3 range = _target - startPosition;

            while (elapsed < _duration)
            {
                elapsed = Mathf.MoveTowards(elapsed, _duration, Time.deltaTime);
                transform.position = startPosition + range * (elapsed / _duration);

                yield return _waitForEndOfFrame;
            }

            transform.position = _target;
        }
    }
}