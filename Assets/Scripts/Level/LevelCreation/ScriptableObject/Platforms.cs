using System.Collections.Generic;
using UnityEngine;

namespace LevelCreation
{
    [System.Serializable]
    public class Platforms
    {
        [SerializeField] private List<int> _indexes = new List<int>();

        public List<int> TakeIndexes() =>
            _indexes;
    }
}