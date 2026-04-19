using System;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        // [SerializeField] private InputService _inputService;
        [SerializeField] private float _speed = 10f;
        private CharacterController _characterController;
        private Camera _camera;
        private float _gravity = -9.81f;
        // private Vector3 _moveDirection;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Look();
        }

        private void Move()
        {
            float move_speed = _speed * Time.deltaTime;

            // float xInput = _inputService.move.x * move_speed;
            float xInput = Input.GetAxis("Horizontal") * move_speed;

            // float zInput = _inputService.move.y * move_speed;
            float zInput = Input.GetAxis("Vertical") * move_speed;

            Vector3 move = new Vector3(xInput, 0, zInput);
            move = Vector3.ClampMagnitude(move, _speed);
            move.y = _gravity;
            move = transform.TransformDirection(move);
            // _moveDirection = transform.right * xInput + transform.forward * zInput;

            // if (_inputService.HasMoveInput())
            // {
            _characterController.Move(move);
            // }
        }

        private void Look()
        {

        }
    }
}

