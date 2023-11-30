using LevelCreation;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private CurrentData _currentData;
    [SerializeField] private PlatformSetter _platformSetter;

    private void Awake()
    {
        _currentData.PreparePlatformIndexes();
        _platformSetter.SetStartPlatforms();

        Time.timeScale = 1;
    }
}