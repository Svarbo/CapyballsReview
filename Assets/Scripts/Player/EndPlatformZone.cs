using UnityEngine;
using UnityEngine.Events;

public class EndPlatformZone : MonoBehaviour
{
    [SerializeField] private GameObject _lowerPlatformPrefab;
    [SerializeField] private CurrentLevelData _currentLevelData;

    private Vector3 _startPosition = new Vector3(0, 10, 50);
    private int _permutationsNumber = 0;
    private bool _isReadyToNextReplace = true;

    private float _lowerPlatformLength => _lowerPlatformPrefab.transform.localScale.x;

    public bool NeedSetNextPlatform => _permutationsNumber != _currentLevelData.NeededPermutationsNumber;

    public event UnityAction Achieved;

    private void Start()
    {
        transform.position = _startPosition;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Ball>(out Ball ball) && _isReadyToNextReplace)
        {
            Achieved?.Invoke();
            Replace();

            _isReadyToNextReplace = false;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Ball>(out Ball ball))
            _isReadyToNextReplace = true;
    }

    private void Replace()
    {
        transform.position += new Vector3(0, 0, _lowerPlatformLength);
        _permutationsNumber++;
    }
}