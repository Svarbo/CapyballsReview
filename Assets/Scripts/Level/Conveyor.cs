using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Rigidbody))]
    public class Conveyor : MonoBehaviour
    {
        [SerializeField] private float _speed = 50;
        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            Vector3 position = _rigidbody.position;
            _rigidbody.position += Vector3.back * _speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(position);
        }
    }
}