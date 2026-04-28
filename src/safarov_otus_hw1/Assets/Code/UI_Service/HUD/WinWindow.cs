using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

namespace Code
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Button _collect_Btn;
        [SerializeField] private Button _advertisement_Btn;

        private CanvasGroup _windowGroup;

        private void Awake()
        {
            gameObject.SetActive(false);
            _windowGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            _playerInput.SwitchCurrentActionMap("UI");
            _windowGroup.DOFade(1f, 1f);
        }

        private void OnEnable()
        {
            _collect_Btn.onClick.AddListener(Collect);
            _advertisement_Btn.onClick.AddListener(Advertising);
        }

        private void OnDisable()
        {
            _collect_Btn.onClick.RemoveListener(Collect);
            _advertisement_Btn.onClick.RemoveListener(Advertising);
        }

        private void Advertising()
        {
            Debug.Log("Реклама");
        }

        private void Collect()
        {
            _windowGroup.DOFade(0f, 1f).OnComplete(() => ExitGame());
        }

        private void ExitGame()
        {
            gameObject.SetActive(false);
            AudioListener.pause = false;
            SceneManager.LoadScene("MainMenu");
        }

    }
}
