using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/LevelsData", fileName = "LevelsData")]
public class LevelsData : ScriptableObject
{
    [SerializeField, HideInInspector] private List<LinksIndexes> _linksIndexes = new List<LinksIndexes>();

    [SerializeField] private LinksIndexes _currentLinksIndexes;

    private int _currentIndex = 0;

    public LinksIndexes GetNeededLinksIndexes(int neededIndex)
    {
        return _linksIndexes[neededIndex];
    }

    public void AddElement()
    {
        if(_linksIndexes == null)
            _linksIndexes = new List<LinksIndexes>();

        _currentLinksIndexes = new LinksIndexes();
        _linksIndexes.Add(_currentLinksIndexes);
        _currentIndex = _linksIndexes.Count - 1;
    }

    public void RemoveCurrentElement()
    {
        if(_currentIndex > 0)
        {
            _currentLinksIndexes = _linksIndexes[--_currentIndex];
            _linksIndexes.RemoveAt(++_currentIndex);
        }
        else
        {
            _linksIndexes.Clear();
            _currentLinksIndexes = null;
        }
    }

    public LinksIndexes TryGetNextLinksIndexes()
    {
        if(_currentIndex < _linksIndexes.Count - 1)
            _currentIndex++;

        _currentLinksIndexes = this[_currentIndex];

        return _currentLinksIndexes;
    }

    public LinksIndexes TryGetPreviousLinksIndexes()
    {
        if (_currentIndex > 0)
            _currentIndex--;

        _currentLinksIndexes = this[_currentIndex];

        return _currentLinksIndexes;
    }

    public LinksIndexes this[int index]
    {
        get
        {
            if (_linksIndexes != null && index >= 0 && index < _linksIndexes.Count)
                return _linksIndexes[index];

            return null;
        }
        set
        {
            if (_linksIndexes == null)
                _linksIndexes = new List<LinksIndexes>();

            if (index >= 0 && index < _linksIndexes.Count && value != null)
                _linksIndexes[index] = value;
            else
                Debug.LogError("Выход за границы массива, либо переданное значение = null");
        }
    }
}

[System.Serializable]
public class LinksIndexes
{
    [SerializeField] private List<int> _indexes = new List<int>();

    public List<int> TakeIndexes()
    { 
        return _indexes;
    }
}