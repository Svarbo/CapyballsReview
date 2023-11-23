using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoader : MonoBehaviour, ISceneLoadHandler<int>
{
    [SerializeField] private ManualPanel _manualPanel;

    public int LevelNumber { get; private set; }

    public void OnSceneLoaded(int levelNumber)
    {
        LevelNumber = levelNumber;

        TryEnableManualPanel();
    }

    private void TryEnableManualPanel()
    {
        _manualPanel.gameObject.SetActive(LevelNumber == 0);
    }
}