using Player;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider))]
    public class BallsRemoveZone : MonoBehaviour
    {
        private BallsContainer _ballsContainer;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if (_ballsContainer == null)
                    _ballsContainer = ball.GetComponentInParent<BallsContainer>();

                _ballsContainer.RemoveBall(ball);
            }
        }
    }
}