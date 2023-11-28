using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Animator))]
    public class Barrier : MonoBehaviour
    {
        [SerializeField] private int _neededBallsCount = 10;

        private Animator _animator;
        private int _open = Animator.StringToHash("Open");

        public int NeededBallsCount => _neededBallsCount;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void Open() =>
            _animator.Play(_open);
    }
}