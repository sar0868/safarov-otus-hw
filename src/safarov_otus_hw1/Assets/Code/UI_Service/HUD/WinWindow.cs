using UnityEngine;
using UnityEngine.InputSystem;

namespace Code
{
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            _playerInput.SwitchCurrentActionMap("UI");
        }
    }
}
