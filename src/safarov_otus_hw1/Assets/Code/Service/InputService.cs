using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code.Service
{
    public sealed class InputService : MonoBehaviour
    {
        public UnityEvent attackEvent = new();
        public UnityEvent jumpEvent = new();
        public Vector2 move;
        public Vector2 look;

        private void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
        }
        private void OnLook(InputValue value)
        {
            look = value.Get<Vector2>();
        }

        private void OnAttack(InputValue value)
        {
            attackEvent?.Invoke();
        }
        private void OnJump(InputValue value)
        {
            jumpEvent?.Invoke();
        }
    }
}

