using UnityEngine;

namespace Code
{
    public interface IInputService
    {
        float GetMoveAxisZ();
        float GetMoveAxisX();
        float GetLookAxisY();
        float GetLookAxisX();
        bool HasJumpInput();
        bool HasMoveInput();
        bool HasLookInput();
        bool HasSootInput();

    }
}