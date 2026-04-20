using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code
{

    public sealed class OldInputService : MonoBehaviour, IInputService
    {
        public UnityEvent jumpEvent = new();

        public bool Jump()
        {
            bool isJump = Input.GetKeyUp(KeyCode.Space);
            if (isJump)
            {
                jumpEvent?.Invoke();
            }
            return isJump;
        }

        public Vector2 Look()
        {
            return new Vector2(Mouse.current.delta.value.x, Mouse.current.delta.value.y);
        }

        public Vector2 Move()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        // public float GetLookAxisX()
        // {
        //     return Mouse.current.delta.value.x;
        // }

        // public float GetLookAxisY()
        // {
        //     return Mouse.current.delta.value.y;
        // }

        // public float GetMoveAxisX()
        // {
        //     return Input.GetAxis("Horizontal");
        // }

        // public float GetMoveAxisZ()
        // {
        //     return Input.GetAxis("Vertical");
        // }

        // public bool HasJumpInput()
        // {
        //     throw new System.NotImplementedException();
        // }

        // public bool HasLookInput()
        // {
        //     return Input.GetKeyUp(KeyCode.Space);
        // }

        // public bool HasMoveInput()
        // {
        //     return GetMoveAxisX() != 0 || GetMoveAxisZ() != 0;
        // }

        // public bool HasSootInput()
        // {
        //     return Input.GetMouseButton(0);
        // }

    }
}