using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{
    public sealed class InputService : MonoBehaviour, IInputService
    {
        public UnityEvent jumpEvent = new();
        private Vector2 _move;
        private Vector2 _look;
        private bool _jump;

        private void OnMove(InputValue value)
        {
            _move = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            _look = value.Get<Vector2>();
        }

        public void OnJump(InputValue value)
        {
            _jump = value.isPressed;
            jumpEvent?.Invoke();
        }
        public bool Jump()
        {
            return _jump;
        }

        public Vector2 Look()
        {
            return _look;
        }

        public Vector2 Move()
        {
            return _move;
        }
    }
}
