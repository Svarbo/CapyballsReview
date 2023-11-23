using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    [SerializeField] private TargetPosition _nextPosition;
     
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<ZoneMover>(out ZoneMover zoneMover))
            zoneMover.SwapCurrentTargetPosition(_nextPosition);
    }
}