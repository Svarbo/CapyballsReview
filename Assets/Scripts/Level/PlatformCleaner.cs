using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformCleaner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Platform>(out Platform platform))
                platform.gameObject.SetActive(false);
        }
    }
}