using UnityEditor;
using UnityEngine;

namespace LevelCreation
{
    [CustomEditor(typeof(Data))]
    public class LevelDataEditor : Editor
    {
        private Data _levelsData;

        private void Awake() =>
            _levelsData = (Data)target;

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Remove"))
                _levelsData.RemoveCurrentElement();
            if (GUILayout.Button("Add"))
                _levelsData.AddElement();
            if (GUILayout.Button("<="))
                _levelsData.TryGetPreviousLinksIndexes();
            if (GUILayout.Button("=>"))
                _levelsData.TryGetNextLinksIndexes();

            GUILayout.EndHorizontal();
            base.OnInspectorGUI();

            if (GUI.changed)
                EditorUtility.SetDirty(_levelsData);
        }
    }
}