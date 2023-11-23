using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gateway : NeedLinksObject
{
    private Animator _animator;
    private int _open = Animator.StringToHash("Open");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        SoundSource.PlaySnakeHitSound();
        _animator.Play(_open);
    }
}