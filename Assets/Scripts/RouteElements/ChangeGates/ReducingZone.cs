public class ReducingZone : ChangeZone
{
    private void OnTriggerEnter(UnityEngine.Collider collider)
    {
        if (collider.TryGetComponent<Ball>(out Ball ball))
        {
            Reduce(ball);

            ChangeDelta--;
            ChangeDeltaText();

            if (ChangeDelta == 0)
                gameObject.SetActive(false);
        }
    }

    private void Reduce(Ball ball)
    {
        Player.RemoveBall(ball);
    }
}