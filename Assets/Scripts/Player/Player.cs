using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agava.YandexGames;

public class Player : MonoBehaviour
{
    [SerializeField] private ObjectPool _ballsPool;
    [SerializeField] private SoundSource _soundSource;

    private List<Ball> _balls = new List<Ball>();
    private Vector3 _ballStartPosition = new Vector3(0.5f, 2, -40);

    public event UnityAction BallsCountDecreased;

    public int BallsCount => _balls.Count;

    private void Start()
    {
        TakeStartBall();
    }

    public void AddBall(Ball newBall)
    {
        _soundSource.PlayAddSound();

        _balls.Add(newBall);
    }

    public void RemoveBall(Ball removedBall)
    {
        _soundSource.PlayOuchSound();

        _balls.Remove(removedBall);
        removedBall.gameObject.SetActive(false);

        BallsCountDecreased?.Invoke();
    }

    public void ReduceScore(int score)
    {
        int currentScore = UnityEngine.PlayerPrefs.GetInt("PlayerScore");
        currentScore += score;

        UnityEngine.PlayerPrefs.SetInt("PlayerScore", currentScore);
        Leaderboard.SetScore("Leaderboard1", currentScore);
    }

    private void TakeStartBall()
    {
        if (_ballsPool.TryGetObject(out GameObject ballObject))
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
        ball.transform.position = _ballStartPosition;
        ball.gameObject.SetActive(true);
    }
}