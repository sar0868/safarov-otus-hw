using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _backGame;
        [SerializeField] private Button _exitManeMenu;
        private bool _isPause;


        private void Awake()
        {
            _isPause = false;
            gameObject.SetActive(false);
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
            Time.timeScale = 1;
            AudioListener.pause = false;
            SceneManager.LoadScene("MainMenu");
        }

        private void BackToGame()
        {
            Resume();
        }

        public void Show()
        {
            if (_isPause == false)
            {
                gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                _isPause = true;
                AudioListener.pause = true;
            }

        }

        private void Resume()
        {
            if (_isPause == true)
            {
                gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                _isPause = false;
                AudioListener.pause = false;
            }
        }

    }

}


