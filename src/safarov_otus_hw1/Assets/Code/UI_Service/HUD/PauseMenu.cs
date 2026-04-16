using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _backGame;
        [SerializeField] private Button _exitManeMenu;
        [SerializeField] private PanelPMenu _panelPMenu;
        private bool _isPause;


        private void Start()
        {
            _panelPMenu.gameObject.SetActive(false);
            _isPause = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }


        private void OnEnable()
        {
            _backGame.onClick.AddListener(BackToGame);
            _exitManeMenu.onClick.AddListener(ExitToManeMenu);
        }

        private void OnDisable()
        {
            _backGame.onClick.RemoveListener(BackToGame);
            _exitManeMenu.onClick.RemoveListener(ExitToManeMenu);
        }

        private void ExitToManeMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void BackToGame()
        {
            Resume();
        }

        private void Pause()
        {
            if (_isPause == false)
            {
                _panelPMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                _isPause = true;
            }

        }

        private void Resume()
        {
            if (_isPause == true)
            {
                _panelPMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                _isPause = false;
            }
        }

    }

}


