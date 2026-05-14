using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.System
{
    public sealed class InputService : MonoBehaviour
    {
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
    }
}

