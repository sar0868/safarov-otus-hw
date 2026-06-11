using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Code.UI_Service
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuBtn;
        [SerializeField] private Button _backGameBtn;
        [SerializeField] private PlayerInput _playerInput;
        private bool _isPause;

        private void Awake()
        {
            _isPause = false;
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _mainMenuBtn.onClick.AddListener(MainMenuBack);
            _backGameBtn.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            _mainMenuBtn.onClick.RemoveListener(MainMenuBack);
            _backGameBtn.onClick.RemoveListener(Back);
        }
        private void Back()
        {
            if (_isPause == true)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                _isPause = false;
                _playerInput.SwitchCurrentActionMap("Player");
                gameObject.SetActive(false);
            }
        }

        public void Show()
        {
            if (_isPause == false)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                _isPause = true;
                _playerInput.SwitchCurrentActionMap("UI");
                gameObject.SetActive(true);
            }
        }


        private void MainMenuBack()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("MainMenu");
        }

    }
}

