using UnityEngine;

namespace ChangeGates
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private bool _moveRightFirst;
        [SerializeField] private TargetPosition _rightTargetPosition;
        [SerializeField] private TargetPosition _leftTargetPosition;
        [SerializeField] private int _speed = 18;

        private TargetPosition _currentTarget;

        private void Awake() =>
            SetMoveDirection();

        private void Update() =>
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);

        public void SwapCurrentTargetPosition(TargetPosition nextPosition) =>
            _currentTarget = nextPosition;

        private void SetMoveDirection()
        {
            if (_moveRightFirst)
                _currentTarget = _rightTargetPosition;
            else
                _currentTarget = _leftTargetPosition;
        }
    }
}