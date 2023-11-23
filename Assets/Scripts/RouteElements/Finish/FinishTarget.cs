using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinishTarget : NeedLinksObject
{
    private int _absorbedBallsCount = 0;
    private int _oneBallReward = 1;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball))
        {
            ball.gameObject.SetActive(false);

            Referee.ReduceScore(_oneBallReward);
            _absorbedBallsCount++;
        }

        if (_absorbedBallsCount == Player.BallsCount)
            Referee.CheckWin();
    }
}