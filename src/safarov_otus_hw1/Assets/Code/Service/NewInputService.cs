using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{
    public sealed class NewInputService : MonoBehaviour, IInputService
    {
        public UnityEvent attackEvent = new();
        public UnityEvent rechargeEvent = new();
        public UnityEvent jumpEvent = new();
        private Vector2 _move;
        private float _look;
        private bool _jump;
        private bool _attack;
        private bool _recharge;


        private void OnMove(InputValue value)
        {
            _move = value.Get<Vector2>();
        }

        private void OnLook(InputValue value)
        {
            _look = value.Get<Vector2>().x;
        }

        private void OnAttack(InputValue value)
        {
            _attack = value.isPressed;
            attackEvent?.Invoke();
        }
        private void OnRecharge(InputValue value)
        {
            _recharge = value.isPressed;
            rechargeEvent?.Invoke();
        }

        private void OnJump(InputValue value)
        {
            _jump = value.isPressed;
            jumpEvent?.Invoke();
        }

        public void Attack()
        {

        }

        public void Jump()
        {

        }

        public float Look()
        {
            return _look;
        }

        public Vector2 Move()
        {
            return _move;
        }
    }

}
