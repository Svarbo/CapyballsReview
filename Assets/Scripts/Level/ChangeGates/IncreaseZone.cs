using Capyballs;
using Player;
using UnityEngine;

namespace ChangeGates
{
    [RequireComponent(typeof(Collider))]
    public class IncreaseZone : ChangeZone
    {
        private ObjectPool _ballsObjectPool;
        private BallsContainer _ballsContainer;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
            {
                if (_ballsObjectPool == null)
                    _ballsObjectPool = ball.GetComponentInParent<ObjectPool>();
                if (_ballsContainer == null)
                    _ballsContainer = ball.GetComponentInParent<BallsContainer>();

                Increase();
                gameObject.SetActive(false);
            }
        }

        private void Increase()
        {
            for (int i = 0; i < ChangeDelta; i++)
            {
                if (_ballsObjectPool.TryGetObject(out GameObject ballPrefab))
                {
                    if (ballPrefab.TryGetComponent<Ball>(out Ball ball))
                        SetBall(ball, transform.position);
                }
            }
        }

        private void SetBall(Ball ball, Vector3 spawnPosition)
        {
            ball.gameObject.SetActive(true);
            ball.transform.position = spawnPosition;
            _ballsContainer.AddBall(ball);
        }
    }
}