using UnityEngine;
using UnityEngine.InputSystem;

namespace Code
{

    public sealed class OldInputService : MonoBehaviour, IInputService
    {
        public float GetLookAxisX()
        {
            return Mouse.current.delta.value.x;
        }

        public float GetLookAxisY()
        {
            return Mouse.current.delta.value.y;
        }

        public float GetMoveAxisX()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetMoveAxisZ()
        {
            return Input.GetAxis("Vertical");
        }

        public bool HasJumpInput()
        {
            throw new System.NotImplementedException();
        }

        public bool HasLookInput()
        {
            return Input.GetKeyUp(KeyCode.Space);
        }

        public bool HasMoveInput()
        {
            return GetMoveAxisX() != 0 || GetMoveAxisZ() != 0;
        }

        public bool HasSootInput()
        {
            return Input.GetMouseButton(0);
        }
    }
}