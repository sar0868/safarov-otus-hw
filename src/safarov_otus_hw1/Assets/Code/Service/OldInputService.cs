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