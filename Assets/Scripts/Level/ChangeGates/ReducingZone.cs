using Player;
using UnityEngine;

namespace ChangeGates
{
    public class ReducingZone : ChangeZone
    {
        private BallsContainer _ballsContainer;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if (_ballsContainer == null)
                    _ballsContainer = ball.GetComponentInParent<BallsContainer>();

                Reduce(ball);

                ChangeDelta--;
                ChangeDeltaText();

                if (ChangeDelta == 0)
                    gameObject.SetActive(false);
            }
        }

        private void Reduce(Ball ball) =>
            _ballsContainer.RemoveBall(ball);
    }
}