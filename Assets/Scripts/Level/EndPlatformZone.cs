using LevelCreation;
using Player;
using System;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider))]
    public class EndPlatformZone : MonoBehaviour
    {
        [SerializeField] private GameObject _lowerPlatformPrefab;
        [SerializeField] private CurrentData _currentData;

        private Vector3 _startPosition = new Vector3(0, 10, 50);
        private int _permutationsNumber = 0;
        private bool _isReadyToNextReplace = true;

        public event Action Achieved;

        public bool NeedSetNextPlatform => _permutationsNumber != _currentData.NeededPermutationsNumber;
        private float LowerPlatformLength => _lowerPlatformPrefab.transform.localScale.x;

        private void Awake() =>
            transform.position = _startPosition;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Ball>(out Ball ball) && _isReadyToNextReplace)
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
            transform.position += new Vector3(0, 0, LowerPlatformLength);
            _permutationsNumber++;
        }
    }
}