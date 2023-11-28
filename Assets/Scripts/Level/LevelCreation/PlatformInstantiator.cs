using Level;
using System.Collections.Generic;
using UnityEngine;

namespace LevelCreation
{
    public class PlatformInstantiator : MonoBehaviour
    {
        [SerializeField] private List<Platform> _platformPrefabs = new List<Platform>();
        [SerializeField] private CurrentData _currentLevelData;
        [SerializeField] private Transform _mapLinksParent;

        public Platform InstantiateNextPlatform()
        {
            int nextPlatformIndex = _currentLevelData.TakeCurrentPlatformIndex();
            Platform newPlatform = Instantiate(_platformPrefabs[nextPlatformIndex], _mapLinksParent);

            return newPlatform;
        }
    }
}