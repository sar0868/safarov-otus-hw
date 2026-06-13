using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public sealed class LoseWindow : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CanvasGroup _background;
        [SerializeField] private CanvasGroup _buttonGroup;
        [SerializeField] private CanvasGroup _textLose;
        [SerializeField] private Button _restart_Btn;
        [SerializeField] private Button _mainMenu_Btn;
        private Sequence _sequence;

        private void Awake()
        {
            gameObject.SetActive(false);

            _background.alpha = 0f;
            _buttonGroup.alpha = 0f;
            _textLose.alpha = 0f;
        }

        private void OnEnable()
        {
            _restart_Btn.onClick.AddListener(Restart);
            _mainMenu_Btn.onClick.AddListener(ExitToManeMenu);
        }

        private void ExitToManeMenu()
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            SceneManager.LoadScene("MainMenu");
        }

        private void Restart()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void OnDisable()
        {
            _restart_Btn.onClick.RemoveListener(Restart);
            _mainMenu_Btn.onClick.RemoveListener(ExitToManeMenu);
        }

        internal void Show()
        {
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            _playerInput.SwitchCurrentActionMap("UI");

            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence();
            _sequence.Append(_background.DOFade(1f, 2f))
            .AppendInterval(1f)
            .Join(_textLose.DOFade(1f, 0.5f))
            .AppendInterval(0.5f)
            .Join(_buttonGroup.DOFade(1f, 0.5f));
        }
    }
}
