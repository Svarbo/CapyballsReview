using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Snare : NeedLinksObject
{
    private int _ballsCounter = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball)) 
        {
            _ballsCounter++;

            if(_ballsCounter == Player.BallsCount)
                Referee.DeclareDefeat();
        }
    }
}