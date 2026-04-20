using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        // [SerializeField] private OldInputService _inputService;
        [SerializeField] private InputService _inputService;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _minimumVert = -40.0f;
        [SerializeField] private float _maximumVert = 45.0f;
        private CharacterController _characterController;
        private Camera _camera;
        private float _gravity = -9.81f;
        private float _rotationX = 0f;
        private float _rotationY = 0f;
        private float _sensitivityLook = 80.0f;
        private Vector3 _velocity = Vector3.zero;
        // private float _jump;
        [SerializeField] private float _jumpHeight = 2f;
        private bool _isGrounded;
        // private Vector3 _moveDirection;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
            // _inputService.jumpEvent.AddListener(OnJump);
        }

        private void Update()
        {
            Move();
            Look();
            OnJump();
        }

        private void OnJump()
        {
            _isGrounded = _characterController.isGrounded;
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
            // _velocity.y
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                // _jump = 0f;
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }

            _velocity.y += _gravity * Time.deltaTime;

            // _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _characterController.Move(_velocity * Time.deltaTime);


        }

        private void Move()
        {
            float move_speed = _speed * Time.deltaTime;

            float xInput = _inputService.Move().x * move_speed;
            float zInput = _inputService.Move().y * move_speed;

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
            _rotationX -= _inputService.Look().y * _sensitivityLook * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);

            _rotationY += _inputService.Look().x * _sensitivityLook * Time.deltaTime;

            _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);

            transform.rotation = Quaternion.Euler(Vector3.up * _rotationY);
        }
    }
}

