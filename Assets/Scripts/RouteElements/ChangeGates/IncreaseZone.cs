using UnityEngine;

public class IncreaseZone : ChangeZone
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball))
        {
            Increase();
            gameObject.SetActive(false);
        }
    }

    private void Increase()
    {
        for(int i = 0; i < ChangeDelta; i++)
        {
            if(BallsPool.TryGetObject(out GameObject ballPrefab))
            {
                if(ballPrefab.TryGetComponent<Ball>(out Ball ball))
                    SetBall(ball, transform.position);
            }
        }
    }

    private void SetBall(Ball ball, Vector3 spawnPosition)
    {
        ball.gameObject.SetActive(true);
        ball.transform.position = spawnPosition;
        Player.AddBall(ball);
    }
}