using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    private float _speed = 50;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 position = _rigidbody.position;
        _rigidbody.position += Vector3.back * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);
    }
}