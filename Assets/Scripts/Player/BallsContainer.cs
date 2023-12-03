using Capyballs;
using ConstantValues;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(ObjectPool))]
    public class BallsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _ballStartPosition;

        private List<Ball> _balls = new List<Ball>();
        private List<Ball> _snairedBalls = new List<Ball>();
        private ObjectPool _objectPool;

        public event Action IsGameEnd;

        public int Score => _balls.Count;
        public int SnairedBallsCount => _snairedBalls.Count;

        private void Start()
        {
            _objectPool = GetComponent<ObjectPool>();

            TakeStartBall();
        }

        public void AddBall(Ball newBall) =>
            _balls.Add(newBall);

        public void EnsnareBall(Ball ensnaredBall)
        {
            _snairedBalls.Add(ensnaredBall);

            if (SnairedBallsCount == Score)
                IsGameEnd?.Invoke();
        }

        public void UnsnaireBall(Ball unsnaredBall) =>
            _snairedBalls.Add(unsnaredBall);

        public void RemoveBall(Ball removedBall)
        {
            _balls.Remove(removedBall);
            removedBall.gameObject.SetActive(false);

            if (Score == 0)
                IsGameEnd?.Invoke();
        }

        public void UpdateLeaderboardScore()
        {
            int currentScore = UnityEngine.PlayerPrefs.GetInt(PlayerPrefsNames.PlayerScore);
            currentScore += Score;

            UnityEngine.PlayerPrefs.SetInt(PlayerPrefsNames.PlayerScore, currentScore);
            Agava.YandexGames.Leaderboard.SetScore(ConstantValues.Leaderboard.Name, currentScore);
        }

        public void AchiveFinish() =>
            IsGameEnd?.Invoke();

        private void TakeStartBall()
        {
            if (_objectPool.TryGetObject(out GameObject ballObject))
            {
                if (ballObject.TryGetComponent<Ball>(out Ball ball))
                {
                    AddBall(ball);
                    SetStartBall(ball);
                }
            }
        }

        private void SetStartBall(Ball ball)
        {
            ball.transform.position = _ballStartPosition.position;
            ball.gameObject.SetActive(true);
        }
    }
}