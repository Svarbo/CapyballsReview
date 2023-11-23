using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 _target;
    private float _duration = 0.8f;

    public void GoToTarget(Vector3 target)
    {
        _target = target;

        StartCoroutine(MoveTo());
    }

    private IEnumerator MoveTo()
    {
        float elapsed = 0;
        Vector3 startPosition = transform.position;
        Vector3 range = _target - startPosition;

        while (elapsed < _duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, _duration, Time.deltaTime);
            transform.position = startPosition + range * (elapsed / _duration);

            yield return new WaitForEndOfFrame();
        }

        transform.position = _target;
    }
}