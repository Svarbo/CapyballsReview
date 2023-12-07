using System.Collections;
using UnityEngine;

namespace Player
{
    public class Ball : MonoBehaviour
    {
        private Vector3 _target;
        private float _duration = 0.8f;
        private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

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
                transform.position = startPosition + (range * (elapsed / _duration));

                yield return _waitForEndOfFrame;
            }

            transform.position = _target;
        }
    }
}