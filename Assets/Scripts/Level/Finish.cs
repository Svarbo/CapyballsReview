using Player;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider))]
    public class Finish : MonoBehaviour
    {
        private BallsContainer _ballContainer;
        private int _absorbedBallsCount = 0;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if(_ballContainer == null)
                    _ballContainer = ball.GetComponentInParent<BallsContainer>();

                AbsorbeBall(ball);
            }

            CheckFinishAchieved();
        }

        private void AbsorbeBall(Ball ball)
        {
            ball.gameObject.SetActive(false);
            _absorbedBallsCount++;
        }

        private void CheckFinishAchieved()
        {
            if (_absorbedBallsCount == _ballContainer.Score)
                _ballContainer.AchiveFinish();
        }
    }
}