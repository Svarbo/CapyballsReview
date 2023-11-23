using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Saw : NeedLinksObject
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Ball>(out Ball ball))
            Player.RemoveBall(ball);
    }
}