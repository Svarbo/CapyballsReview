using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BallsRemoveZone : NeedLinksObject
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball))
            Player.RemoveBall(ball);
    }
}