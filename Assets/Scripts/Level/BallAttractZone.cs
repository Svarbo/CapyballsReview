using Player;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider))]
    public class BallAttractZone : MonoBehaviour
    {
        [SerializeField] private Finish _finishTarget;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball))
                ball.Forward(_finishTarget.transform.position);
        }
    }
}