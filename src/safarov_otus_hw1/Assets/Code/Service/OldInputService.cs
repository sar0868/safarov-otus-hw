using UnityEngine;
using UnityEngine.InputSystem;

namespace Code
{

    public sealed class OldInputService : MonoBehaviour, IInputService
    {

        public bool Jump()
        {
            return Input.GetButtonDown("Jump");
        }

        public Vector2 Look()
        {
            return new Vector2(Mouse.current.delta.value.x, Mouse.current.delta.value.y);
        }

        public Vector2 Move()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

    }
}