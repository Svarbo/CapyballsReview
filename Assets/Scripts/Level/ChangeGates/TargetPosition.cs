using UnityEngine;

namespace ChangeGates
{
    [RequireComponent(typeof(Collider))]
    public class TargetPosition : MonoBehaviour
    {
        [SerializeField] private TargetPosition _nextPosition;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Mover>(out Mover zoneMover))
                zoneMover.SwapCurrentTargetPosition(_nextPosition);
        }
    }
}