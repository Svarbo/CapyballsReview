using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class MapCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Platform>(out Platform platform))
            platform.gameObject.SetActive(false);
    }
}