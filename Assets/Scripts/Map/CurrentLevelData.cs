using System.Collections.Generic;
using UnityEngine;

public class CurrentLevelData : MonoBehaviour
{
    private const int FinishGatesPlatformIndex = 13;
    private const int FinishPlatformIndex = 14;

    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private LevelLoader _levelLoader;

    private List<int> _platformIndexes = new List<int>();
    private int _currentPlatformIndex = -1;

    public int PlatformIndexesCount => _platformIndexes.Count;
    public int NeededPermutationsNumber => _platformIndexes.Count - 2;

    private void Awake()
    {
        Time.timeScale = 1;

        PreparePlatformIndexes(_levelLoader.LevelNumber);
    }

    private void PreparePlatformIndexes(int levelNumber)
    {
        LinksIndexes linksIndexes = _levelsData.GetNeededLinksIndexes(levelNumber);
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

    public int TakeCurrentPlatformIndex()
    {
        _currentPlatformIndex++;

        return _platformIndexes[_currentPlatformIndex];
    }
}