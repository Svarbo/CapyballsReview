using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private EndPlatformZone _endPlatformZone;
    [SerializeField] private int _speed = 100;

    private Vector3 _startPosition = new Vector3(0, 55, -50);
    private Vector3 _nextPosition;

    private void Start()
    {
        transform.position = _startPosition;
        _nextPosition = transform.position;
    }

    private void OnEnable()
    {
        _endPlatformZone.Achieved += SetNextPosition;
    }

    private void OnDisable()
    {
        _endPlatformZone.Achieved -= SetNextPosition;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);
    }

    private void SetNextPosition()
    {
        _nextPosition = new Vector3(transform.position.x, transform.position.y, _endPlatformZone.transform.position.z);
    }
}