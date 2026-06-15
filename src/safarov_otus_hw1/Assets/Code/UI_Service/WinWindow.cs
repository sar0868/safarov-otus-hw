using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Code.UI_Service
{
    public sealed class WinWindow : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuBtn;
        [SerializeField] private Button _restartGameBtn;
        [SerializeField] private PlayerInput _playerInput;


        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _mainMenuBtn.onClick.AddListener(MainMenuBack);
            _restartGameBtn.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _mainMenuBtn.onClick.RemoveListener(MainMenuBack);
            _restartGameBtn.onClick.RemoveListener(Restart);
        }
        private void Restart()
        {

            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("SampleScene");

        }

        public void Show()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            _playerInput.SwitchCurrentActionMap("UI");
            gameObject.SetActive(true);
        }


        private void MainMenuBack()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("MainMenu");
        }

    }
}

