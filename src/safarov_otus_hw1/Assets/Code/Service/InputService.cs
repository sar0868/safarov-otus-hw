using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{
    public sealed class InputService : MonoBehaviour
    {
        public Vector2 move;
        public Vector2 look;

        public void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            look = value.Get<Vector2>();
        }
    }
}
