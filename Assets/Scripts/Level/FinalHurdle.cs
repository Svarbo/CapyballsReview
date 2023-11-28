using Player;
using TMPro;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider))]
    public class FinalHurdle : MonoBehaviour
    {
        [SerializeField] private Barrier _barrier;
        [SerializeField] private TMP_Text _neededBallsText;

        private BallsContainer _ballsContainer;
        private int _ballsCount = 0;

        private void Awake() =>
            ChangeNeededBallsText();

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if (_ballsContainer == null)
                    _ballsContainer = ball.GetComponentInParent<BallsContainer>();

                CountBall(ball);
                TryOpenGates();
            }
        }

        private void ChangeNeededBallsText()
        {
            int remains = Mathf.Clamp(_barrier.NeededBallsCount - _ballsCount, 0, _barrier.NeededBallsCount);
            _neededBallsText.text = remains.ToString();
        }

        private void CountBall(Ball ball)
        {
            _ballsCount++;
            ChangeNeededBallsText();
            _ballsContainer.EnsnareBall(ball);
        }

        private bool TryOpenGates()
        {
            bool isEnough = _ballsCount >= _barrier.NeededBallsCount;

            if (isEnough)
                _barrier.Open();

            return isEnough;
        }
    }
}