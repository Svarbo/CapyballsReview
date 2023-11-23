using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiator : MonoBehaviour
{
    [SerializeField] private List<Platform> _platformPrefabs = new List<Platform>();
    [SerializeField] private CurrentLevelData _currentLevelData;
    [SerializeField] private Transform _mapLinksParent;
    [SerializeField] private Player _player;
    [SerializeField] private ObjectPool _ballsPool;
    [SerializeField] private Referee _referee;
    [SerializeField] private SoundSource _soundSource;

    public Platform InstantiateNextPlatform()
    {
        int nextPlatformIndex = _currentLevelData.TakeCurrentPlatformIndex();
        Platform newPlatform = Instantiate(_platformPrefabs[nextPlatformIndex], _mapLinksParent);

        newPlatform.InsertNeededLinks(_player, _ballsPool, _referee, _soundSource);

        return newPlatform;
    }
}