using GameLoading;
using System.Collections.Generic;
using UnityEngine;

namespace LevelCreation
{
    public class CurrentData : MonoBehaviour
    {
        private const int FinishGatesPlatformIndex = 13;
        private const int FinishPlatformIndex = 14;
        private const int SpecialPlatformsCount = 2;

        [SerializeField] private Data _data;
        [SerializeField] private LevelLoader _levelLoader;

        private List<int> _platformIndexes = new List<int>();
        private int _currentPlatformIndex = -1;

        public int NeededPermutationsNumber => _platformIndexes.Count - SpecialPlatformsCount;

        public int TakeCurrentPlatformIndex()
        {
            _currentPlatformIndex++;

            return _platformIndexes[_currentPlatformIndex];
        }

        public void PreparePlatformIndexes()
        {
            Platforms linksIndexes = _data.GetNeededLinksIndexes(_levelLoader.LevelNumber);
            List<int> indexes = linksIndexes.TakeIndexes();

            foreach (int index in indexes)
                _platformIndexes.Add(index);

            AddLastPlatforms();
        }

        private void AddLastPlatforms()
        {
            _platformIndexes.Add(FinishGatesPlatformIndex);
            _platformIndexes.Add(FinishPlatformIndex);
        }
    }
}