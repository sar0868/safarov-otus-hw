using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{

    public sealed class OldInputService : MonoBehaviour, IInputService
    {
        public UnityEvent jumpEvent = new();
        public UnityEvent attackEvent = new();

        void Update()
        {
            Jump();
            Attack();
        }

        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                attackEvent?.Invoke();
            }
        }

        public void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpEvent?.Invoke();
            }
        }

        public float Look()
        {
            return Mouse.current.delta.value.x;
        }

        public Vector2 Move()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

    }
}