using UnityEngine;

namespace Code
{
    public interface IInputService
    {
        // float GetMoveAxisZ();
        // float GetMoveAxisX();
        // float GetLookAxisY();
        // float GetLookAxisX();
        // bool HasJumpInput();
        // bool HasMoveInput();
        // bool HasLookInput();
        // bool HasShootInput();

        public Vector2 Move();

        public Vector2 Look();

        public bool Jump();
    }
}