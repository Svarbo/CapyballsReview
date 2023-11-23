using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinishZone : MonoBehaviour
{
    [SerializeField] private Transform _finishTarget;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball))
            ball.GoToTarget(_finishTarget.position);
    }
}