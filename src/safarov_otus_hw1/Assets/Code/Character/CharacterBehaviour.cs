using Code.System;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private float _speed = 8f;
        [SerializeField] private float _turn = 8f;


        private Rigidbody _rigidbody;
        private float _rotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            float zInput = _inputService.move.y * _speed;
            float xInput = _inputService.move.x * _speed;

            // Vector3 rotation = Vector3.up * _inputService.move.x * _turn;
            _rotation += _inputService.look * _turn;

            // Quaternion angle = Quaternion.Euler(rotation * Time.fixedDeltaTime);
            Quaternion angle = Quaternion.Euler(Vector3.up * _rotation * Time.fixedDeltaTime);
            _rigidbody.MovePosition(transform.position + transform.forward * zInput * Time.fixedDeltaTime + transform.right * xInput * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(angle);
        }
    }

}
