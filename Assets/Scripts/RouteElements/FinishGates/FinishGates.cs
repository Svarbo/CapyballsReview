using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinishGates : MonoBehaviour
{
    private Animator _animator;
    private int _open = Animator.StringToHash("Open");
    private int _reward;
    private int _neededBallsCount = 10;

    public int NeededBallsCount => _neededBallsCount;
    public int Reward => _reward;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.Play(_open);
    }
}