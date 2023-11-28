using System.Collections.Generic;
using UnityEngine;

namespace LevelCreation
{
    [CreateAssetMenu(menuName = "Database/LevelsData", fileName = "LevelsData")]
    public class Data : ScriptableObject
    {
        [SerializeField] private Platforms _currentLinksIndexes;

        private List<Platforms> _platforms = new List<Platforms>();
        private int _currentIndex = 0;

        public int PlatformsCount => _platforms.Count;

        public Platforms GetNeededLinksIndexes(int neededIndex) =>
            _platforms[neededIndex];

        public void AddElement()
        {
            if (_platforms == null)
                _platforms = new List<Platforms>();

            _currentLinksIndexes = new Platforms();
            _platforms.Add(_currentLinksIndexes);
            _currentIndex = _platforms.Count - 1;
        }

        public void RemoveCurrentElement()
        {
            if (_currentIndex > 0)
            {
                _currentLinksIndexes = _platforms[--_currentIndex];
                _platforms.RemoveAt(++_currentIndex);
            }
            else
            {
                _platforms.Clear();
                _currentLinksIndexes = null;
            }
        }

        public Platforms TryGetNextLinksIndexes()
        {
            if (_currentIndex < _platforms.Count - 1)
                _currentIndex++;

            _currentLinksIndexes = this[_currentIndex];

            return _currentLinksIndexes;
        }

        public Platforms TryGetPreviousLinksIndexes()
        {
            if (_currentIndex > 0)
                _currentIndex--;

            _currentLinksIndexes = this[_currentIndex];

            return _currentLinksIndexes;
        }

        public Platforms this[int index]
        {
            get
            {
                if (_platforms != null && index >= 0 && index < _platforms.Count)
                    return _platforms[index];

                return null;
            }
            set
            {
                if (_platforms == null)
                    _platforms = new List<Platforms>();

                if (index >= 0 && index < _platforms.Count && value != null)
                    _platforms[index] = value;
            }
        }
    }
}