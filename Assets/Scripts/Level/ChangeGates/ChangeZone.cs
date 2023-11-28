using TMPro;
using UnityEngine;

namespace ChangeGates
{
    [RequireComponent(typeof(Collider))]
    public abstract class ChangeZone : MonoBehaviour
    {
        protected int ChangeDelta;

        [SerializeField] private TMP_Text _text;

        private int _minDeltaValue = 5;
        private int _maxDeltaValue = 15;

        private void Awake()
        {
            ChangeDelta = Random.Range(_minDeltaValue, _maxDeltaValue);
            ChangeDeltaText();
        }

        protected void ChangeDeltaText() =>
            _text.text = ChangeDelta.ToString();
    }
}