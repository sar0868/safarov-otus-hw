using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{
    public sealed class NewInputService : MonoBehaviour
    {
        public UnityEvent attackEvent = new();
        public UnityEvent rechargeEvent = new();
        public UnityEvent jumpEvent = new();
        public Vector2 move;
        public float look;

        private void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
        }

        private void OnLook(InputValue value)
        {
            look = value.Get<Vector2>().x;
        }

        private void OnAttack(InputValue value)
        {
            attackEvent?.Invoke();
        }
        private void OnRecharge(InputValue value)
        {
            rechargeEvent?.Invoke();
        }

        private void OnJump(InputValue value)
        {
            jumpEvent?.Invoke();
        }
    }
}
