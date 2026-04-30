using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NewInputService _inputService;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _sensitivityLook = 20.0f;
        [SerializeField] private Animator _animator;
        private CharacterController _characterController;
        private float _gravity = -9.81f;
        private float _rotationY = 0f;
        private bool _isGrounded;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _inputService.jumpEvent.AddListener(OnJump);
            Cursor.lockState = CursorLockMode.Locked;
        }


        private void Update()
        {
            Look();
            Move();
        }

        private void OnJump()
        {
            _animator.SetTrigger("Jump");
        }

        private void Move()
        {
            float move_speed = _speed * Time.deltaTime;

            float xInput = _inputService.move.x * move_speed;
            float zInput = _inputService.move.y * move_speed;



            if (_inputService.move.y != 0)
            {
                _animator.SetBool("Move", true);
            }
            else
            {
                _animator.SetBool("Move", false);
            }

            if (xInput > 0)
            {
                _animator.SetBool("Left", true);
            }
            else if (xInput < 0)
            {
                _animator.SetBool("Right", true);
            }
            else
            {
                _animator.SetBool("Left", false);
                _animator.SetBool("Right", false);
            }


            Vector3 move = new Vector3(xInput, 0, zInput);
            move = Vector3.ClampMagnitude(move, _speed);
            move.y = _gravity;
            move = transform.TransformDirection(move);

            _characterController.Move(move);
        }

        private void Look()
        {
            _rotationY += _inputService.look * _sensitivityLook * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.up * _rotationY);
        }
    }
}
