using IJunior.TypedScenes;
using UI;
using UnityEngine;

namespace GameLoading
{
    public class LevelLoader : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private LearningPanel _learningPanel;

        public int LevelNumber { get; private set; }

        public void OnSceneLoaded(int levelNumber)
        {
            LevelNumber = levelNumber;
            EnableLearningPanel();
        }

        private void EnableLearningPanel() =>
            _learningPanel.gameObject.SetActive(LevelNumber == 0);
    }
}