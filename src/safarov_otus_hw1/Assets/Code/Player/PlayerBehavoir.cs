using Code.Service;
using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBehavoir : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private float _speed = 8f;
        [SerializeField] private float _sensivityRotation = 8f;
        [SerializeField] private float _jumpForce = 8f;
        [SerializeField] private float _minVert = -30f;
        [SerializeField] private float _maxVert = 45f;
        [SerializeField] private LayerMask _groundLayer;

        private float _distantceToGround = 0.1f;
        private Rigidbody _rigidbody;
        private CapsuleCollider _collider;
        private Camera _camera;
        private float _rotationY;
        private float _rotationX;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<CapsuleCollider>();
            _camera = Camera.main;
            _inputService.jumpEvent.AddListener(OnJump);
        }

        private void OnJump()
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }

        private void FixedUpdate()
        {
            Look();
            MovementPlayer();
        }

        private void Look()
        {
            _rotationX -= _inputService.look.y * _sensivityRotation * Time.fixedDeltaTime;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
            _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);

            _rotationY += _inputService.look.x * _sensivityRotation * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(Vector3.up * _rotationY);
        }

        private void MovementPlayer()
        {
            float xInput = _inputService.move.x * _speed;
            float zInput = _inputService.move.y * _speed;

            Vector3 move = new Vector3(xInput, 0, zInput) * Time.fixedDeltaTime;

            _rigidbody.AddRelativeForce(move, ForceMode.Impulse);
        }

        private bool IsGrounded()
        {
            Vector3 capsuleBottom = new Vector3(
                _collider.bounds.center.x,
                _collider.bounds.min.y,
                _collider.bounds.center.z);

            bool grounded = Physics.CheckCapsule(
                 _collider.bounds.center,
                 capsuleBottom,
                 _distantceToGround,
                 _groundLayer,
                 QueryTriggerInteraction.Ignore);

            return grounded;
        }
    }

}
