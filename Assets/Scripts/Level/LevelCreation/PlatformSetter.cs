using Level;
using UnityEngine;

namespace LevelCreation
{
    public class PlatformSetter : MonoBehaviour
    {
        private const int VisiblePlatformsNumber = 2;

        [SerializeField] private EndPlatformZone _endPlatformZone;
        [SerializeField] private GameObject _lowerPlatformPrefab;
        [SerializeField] private PlatformInstantiator _platformInstantiator;

        private Vector3 _currentPosition = Vector3.zero;

        private float LowerPlatformLength => _lowerPlatformPrefab.transform.localScale.x;

        private void OnEnable() =>
            _endPlatformZone.Achieved += SetNextPlatform;

        private void OnDisable() =>
            _endPlatformZone.Achieved -= SetNextPlatform;

        public void SetStartPlatforms()
        {
            for (int i = 0; i < VisiblePlatformsNumber; i++)
                SetNextPlatform();
        }

        private void SetNextPlatform()
        {
            if (_endPlatformZone.NeedSetNextPlatform)
            {
                Platform platform = _platformInstantiator.InstantiateNextPlatform();

                platform.transform.position = _currentPosition;
                _currentPosition += new Vector3(0, 0, LowerPlatformLength);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}