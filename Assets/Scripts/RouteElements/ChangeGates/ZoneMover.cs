using UnityEngine;

public class ZoneMover : MonoBehaviour
{
    [SerializeField] private bool _moveRightFirst;
    [SerializeField] private TargetPosition _rightTargetPosition;
    [SerializeField] private TargetPosition _leftTargetPosition;

    private int _speed = 18;
    private TargetPosition _currentTarget;

    private void Awake()
    {
        SetMoveDirection();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);
    }

    private void SetMoveDirection()
    {
        if (_moveRightFirst)
            _currentTarget = _rightTargetPosition;
        else
            _currentTarget = _leftTargetPosition;
    }

    public void SwapCurrentTargetPosition(TargetPosition nextPosition)
    {
        _currentTarget = nextPosition;
    }
}