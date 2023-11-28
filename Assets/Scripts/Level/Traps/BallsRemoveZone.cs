using Player;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider))]
    public class BallsRemoveZone : MonoBehaviour
    {
        private BallsContainer _ballContainer;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if(_ballContainer == null)
                    _ballContainer = GetComponentInParent<BallsContainer>();

                _ballContainer.RemoveBall(ball);
            }
        }
    }
}