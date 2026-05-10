using UnityEngine;

namespace Code.Service
{
    public sealed class SettingsPlay : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}

